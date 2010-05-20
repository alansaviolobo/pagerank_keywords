using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace PageRankKeywords
{
	#region ResultLink structure

	struct ResultLink
	{
		/// <summary>
		/// Search result rank of the link
		/// </summary>
		public int Rank { get; set; }

		/// <summary>
		/// Link of the result
		/// </summary>
		public string Link { get; set; }

		/// <summary>
		/// Pagerank of the link
		/// </summary>
		public int Pagerank { get; set; }
	}

	#endregion

	public partial class frmMain : Form
	{
		#region Private members

		/// <summary>
		/// Cache for pageranks retrieved in the session
		/// </summary>
		Dictionary<string, int> dctPageranks;

		int linkRank;
		/// <summary>
		/// Dictionary to store the results and information
		/// </summary>
		Dictionary<string, List<ResultLink>> dctLinks;

		// Members to handle keywords
		int keywordCounter;
		string currentKeyword;
		List<string> lstKeywords;

		// Blacklist
		List<string> lstBlacklist;

		// Silverlist
		List<string> lstSilverlist;

		#endregion

		#region Initialization

		public frmMain()
		{
			InitializeComponent();
		}

		private void frmMain_Load(object sender, EventArgs e)
		{
			try
			{
				lstBlacklist = FileToList(Properties.Settings.Default.BlacklistFilename);
			}
			catch (Exception) { }

			try
			{
				lstSilverlist = FileToList(Properties.Settings.Default.SilverlistFilename);
			}
			catch (Exception) { }
		}

		#endregion

		#region Button event handlers

		private void btnStart_Click(object sender, EventArgs e)
		{
			if (lstKeywords == null || lstKeywords.Count == 0)
			{
				MessageBox.Show("Nothing to scrape. Please select a file with at least one keyword.");
				btnBrowseKeyword.Focus();
				return;
			}

			if (txtOutput.Text == "")
			{
				MessageBox.Show("Please select an output file.");
				btnBrowseOutput.Focus();
				return;
			}

			Log("Starting scraping");

			SetControlsState(false);

			dctPageranks = new Dictionary<string, int>();
			dctLinks = new Dictionary<string, List<ResultLink>>();

			keywordCounter = 0;
			ContinueScraping();
		}

		private void btnStop_Click(object sender, EventArgs e)
		{
			StopOperation("User Cancel");
		}

		private void btnBrowseKeyword_Click(object sender, EventArgs e)
		{
			ofd.Title = "Specify keywords list file";
			ofd.FileName = txtKeyword.Text;
			ofd.Filter = "Text files|*.txt|All|*";
			if (ofd.ShowDialog() == DialogResult.OK)
			{
				try
				{
					txtKeyword.Text = ofd.FileName;
					lstKeywords = new List<string>();

					using (var sr = new StreamReader(txtKeyword.Text))
					{
						while (!sr.EndOfStream)
						{
							var line = sr.ReadLine().Trim();
							if (line != "" && !lstKeywords.Contains(line))
							{
								lstKeywords.Add(line);
							}
						}
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show(string.Format("There was an error while reading from the file: {0}", ex.Message), ex.GetType().ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
					lstKeywords = null;
					txtKeyword.Text = "";
				}
			}
		}

		private void btnBrowseOutput_Click(object sender, EventArgs e)
		{
			sfd.Title = "Specify Results file";
			sfd.FileName = txtOutput.Text;
			sfd.Filter = "CSV File|*.csv|All|*";
			if (sfd.ShowDialog() == DialogResult.OK)
			{
				txtOutput.Text = sfd.FileName;
			}
		}

		#endregion

		#region WebBrowser functions

		private void brwsr_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
		{
			try
			{
				if (dctLinks[currentKeyword].Count > nudMaxLinks.Value)
				{
					ContinueScraping();
					return;
				}

				if (dctLinks[currentKeyword].Count < nudMaxLinks.Value)
				{
					var doc = brwsr.Document;

					// Go through all <h3> tags
					foreach (HtmlElement result in doc.GetElementsByTagName("h3"))
					{
						// We are looking for <h3 class=r>
						if (!result.OuterHtml.Trim().ToLower().StartsWith("<h3 class=r>"))
						{
							continue;
						}

						// Get the first link in the element
						var aElements = result.GetElementsByTagName("a");
						if (aElements.Count == 0)
						{
							Log("Skipped an invalid member");
							continue;
						}

						var aElement = aElements[0];
						var link = aElement.GetAttribute("href");
						linkRank++;

						// Just in case we get the link again
						if (LinkScanned(link))
						{
							continue;
						}

						// Check the link contents against the blacklist
						if (CheckLinkInList(link, lstBlacklist))
						{
							Log(string.Format("Skipping blacklisted link {0}", link));
							continue;
						}

						var pagerank = chkPagerank.Checked ? GetPagerank(link) : -1;
						if (CheckLinkInList(link, lstSilverlist))
						{
							Log(string.Format("Found silverlisted link {0}", link));
							pagerank = (pagerank == -1) ? 21 : pagerank + 10;
						}

						dctLinks[currentKeyword].Add(new ResultLink()
						{
							Rank = linkRank,
							Link = link,
							Pagerank = pagerank
						});
					}

					// If we have hit the limit, continue with the next keyword
					if (dctLinks[currentKeyword].Count >= nudMaxLinks.Value)
					{
						ContinueScraping();
						return;
					}

					// Find the 'Next' link and click on it if applicable
					bool nextLinkFound = FindNextLinkAndClick(doc);
					if (nextLinkFound)
					{
						Log(string.Format("Moving to next page. We have read {0} links.", dctLinks[currentKeyword].Count));
					}
					else
					{
						// We are out of results
						// Continue with the next keyword
						ContinueScraping();
						return;
					}
				}
			}
			catch (Exception ex)
			{
				StopOperation(string.Format("Exception {0} thrown: {1}", ex.GetType().ToString(), ex.Message));
			}
		}

		private bool FindNextLinkAndClick(HtmlDocument doc)
		{
			// Find the next link and click it
			bool nextLinkFound = false;
			foreach (HtmlElement a in doc.GetElementsByTagName("a"))
			{
				if (a.InnerText == "Next")
				{
					// We found the link, click it
					nextLinkFound = true;
					a.InvokeMember("click");
					break;
				}
			}
			return nextLinkFound;
		}

		private void StopOperation(string message)
		{
			Log("Stopping operation: " + message);
			brwsr.Stop();
			SetControlsState(true);
		}

		#endregion

		#region Utility methods

		private static List<string> FileToList(string filename)
		{
			var lst = new List<string>();

			using (var sr = new StreamReader(filename))
			{
				while (!sr.EndOfStream)
				{
					var line = sr.ReadLine().Trim().ToLower();
					if (line != "")
					{
						lst.Add(line);
					}
				}
			}
			return lst;
		}

		private void SetControlsState(bool enabled)
		{
			txtKeyword.Enabled = btnBrowseKeyword.Enabled = txtOutput.Enabled = btnBrowseOutput.Enabled = enabled;
			nudMaxLinks.Enabled = chkPagerank.Enabled = btnStart.Enabled = enabled;
			btnStop.Enabled = !enabled;
		}

		private void ContinueScraping()
		{
			if (keywordCounter >= lstKeywords.Count)
			{
				StopOperation("Done Scraping");
				SaveFile();
				Log(string.Format("Results for {0} keywords saved to {1}", dctLinks.Count, txtOutput.Text));

				return;
			}

			currentKeyword = lstKeywords[keywordCounter++];
			Log(string.Format("Retrieving results for {0}", currentKeyword));

			dctLinks.Add(currentKeyword, new List<ResultLink>());

			linkRank = -1;
			brwsr.Navigate(string.Format(Properties.Settings.Default.SearchStartFormat, currentKeyword));
		}

		private bool LinkScanned(string link)
		{
			var found = false;
			foreach (var rLink in dctLinks[currentKeyword])
			{
				if (rLink.Link == link)
				{
					found = true;
					break;
				}
			}
			return found;
		}

		private bool CheckLinkInList(string link, List<string> list)
		{
			var found = false;
			var lnk = link.ToLower();
			foreach (var bl in list)
			{
				if (lnk.Contains(bl))
				{
					found = true;
					break;
				}
			}
			return found;
		}

		private int GetPagerank(string link)
		{
			if (!dctPageranks.ContainsKey(link))
			{
				var pr = GooglePR.Pagerank.Get(link);
				dctPageranks.Add(link, pr);
				return pr;
			}
			else
			{
				return dctPageranks[link];
			}
		}

		private void SaveFile()
		{
			try
			{
				using (StreamWriter sw = new StreamWriter(txtOutput.Text))
				{
					sw.WriteLine("Keyword,Rank,URL,Pagerank");

					foreach (var entry in dctLinks)
					{
						foreach (var links in entry.Value)
						{
							sw.WriteLine(string.Format("\"{0}\",{1},\"{2}\",{3}", entry.Key, links.Rank, links.Link, links.Pagerank));
						}
					}

					sw.Close();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(string.Format("There was an error while writing the file: {0}", ex.Message), ex.GetType().ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void Log(string line)
		{
			txtLog.Text += line + Environment.NewLine;
			txtLog.SelectionStart = txtLog.Text.Length;
			txtLog.ScrollToCaret();
		}

		#endregion
	}
}