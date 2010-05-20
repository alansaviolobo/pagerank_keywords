namespace PageRankKeywords
{
	partial class frmMain
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.label1 = new System.Windows.Forms.Label();
			this.txtKeyword = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.nudMaxLinks = new System.Windows.Forms.NumericUpDown();
			this.btnStart = new System.Windows.Forms.Button();
			this.btnStop = new System.Windows.Forms.Button();
			this.tabStatus = new System.Windows.Forms.TabControl();
			this.tabLog = new System.Windows.Forms.TabPage();
			this.txtLog = new System.Windows.Forms.TextBox();
			this.tabWB = new System.Windows.Forms.TabPage();
			this.brwsr = new System.Windows.Forms.WebBrowser();
			this.btnBrowseKeyword = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.btnBrowseOutput = new System.Windows.Forms.Button();
			this.txtOutput = new System.Windows.Forms.TextBox();
			this.chkPagerank = new System.Windows.Forms.CheckBox();
			this.ofd = new System.Windows.Forms.OpenFileDialog();
			this.sfd = new System.Windows.Forms.SaveFileDialog();
			((System.ComponentModel.ISupportInitialize)(this.nudMaxLinks)).BeginInit();
			this.tabStatus.SuspendLayout();
			this.tabLog.SuspendLayout();
			this.tabWB.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 17);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(67, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "&Keyword File";
			// 
			// txtKeyword
			// 
			this.txtKeyword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtKeyword.BackColor = System.Drawing.SystemColors.Window;
			this.txtKeyword.Location = new System.Drawing.Point(85, 14);
			this.txtKeyword.Name = "txtKeyword";
			this.txtKeyword.ReadOnly = true;
			this.txtKeyword.Size = new System.Drawing.Size(291, 20);
			this.txtKeyword.TabIndex = 1;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(47, 75);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(32, 13);
			this.label2.TabIndex = 6;
			this.label2.Text = "&Links";
			// 
			// nudMaxLinks
			// 
			this.nudMaxLinks.Location = new System.Drawing.Point(85, 73);
			this.nudMaxLinks.Name = "nudMaxLinks";
			this.nudMaxLinks.Size = new System.Drawing.Size(44, 20);
			this.nudMaxLinks.TabIndex = 7;
			this.nudMaxLinks.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
			// 
			// btnStart
			// 
			this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnStart.Location = new System.Drawing.Point(249, 70);
			this.btnStart.Name = "btnStart";
			this.btnStart.Size = new System.Drawing.Size(75, 23);
			this.btnStart.TabIndex = 9;
			this.btnStart.Text = "&Start";
			this.btnStart.UseVisualStyleBackColor = true;
			this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
			// 
			// btnStop
			// 
			this.btnStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnStop.Enabled = false;
			this.btnStop.Location = new System.Drawing.Point(330, 70);
			this.btnStop.Name = "btnStop";
			this.btnStop.Size = new System.Drawing.Size(75, 23);
			this.btnStop.TabIndex = 10;
			this.btnStop.Text = "S&top";
			this.btnStop.UseVisualStyleBackColor = true;
			this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
			// 
			// tabStatus
			// 
			this.tabStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.tabStatus.Controls.Add(this.tabLog);
			this.tabStatus.Controls.Add(this.tabWB);
			this.tabStatus.Location = new System.Drawing.Point(12, 99);
			this.tabStatus.Name = "tabStatus";
			this.tabStatus.SelectedIndex = 0;
			this.tabStatus.Size = new System.Drawing.Size(393, 194);
			this.tabStatus.TabIndex = 11;
			// 
			// tabLog
			// 
			this.tabLog.Controls.Add(this.txtLog);
			this.tabLog.Location = new System.Drawing.Point(4, 22);
			this.tabLog.Name = "tabLog";
			this.tabLog.Padding = new System.Windows.Forms.Padding(3);
			this.tabLog.Size = new System.Drawing.Size(385, 168);
			this.tabLog.TabIndex = 0;
			this.tabLog.Text = "Log";
			this.tabLog.UseVisualStyleBackColor = true;
			// 
			// txtLog
			// 
			this.txtLog.BackColor = System.Drawing.SystemColors.Window;
			this.txtLog.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtLog.Location = new System.Drawing.Point(3, 3);
			this.txtLog.Multiline = true;
			this.txtLog.Name = "txtLog";
			this.txtLog.ReadOnly = true;
			this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtLog.Size = new System.Drawing.Size(379, 162);
			this.txtLog.TabIndex = 0;
			// 
			// tabWB
			// 
			this.tabWB.Controls.Add(this.brwsr);
			this.tabWB.Location = new System.Drawing.Point(4, 22);
			this.tabWB.Name = "tabWB";
			this.tabWB.Padding = new System.Windows.Forms.Padding(3);
			this.tabWB.Size = new System.Drawing.Size(385, 168);
			this.tabWB.TabIndex = 1;
			this.tabWB.Text = "Browser";
			this.tabWB.UseVisualStyleBackColor = true;
			// 
			// brwsr
			// 
			this.brwsr.Dock = System.Windows.Forms.DockStyle.Fill;
			this.brwsr.Location = new System.Drawing.Point(3, 3);
			this.brwsr.MinimumSize = new System.Drawing.Size(20, 20);
			this.brwsr.Name = "brwsr";
			this.brwsr.ScriptErrorsSuppressed = true;
			this.brwsr.Size = new System.Drawing.Size(379, 162);
			this.brwsr.TabIndex = 0;
			this.brwsr.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.brwsr_DocumentCompleted);
			// 
			// btnBrowseKeyword
			// 
			this.btnBrowseKeyword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnBrowseKeyword.Location = new System.Drawing.Point(382, 12);
			this.btnBrowseKeyword.Name = "btnBrowseKeyword";
			this.btnBrowseKeyword.Size = new System.Drawing.Size(23, 23);
			this.btnBrowseKeyword.TabIndex = 2;
			this.btnBrowseKeyword.Text = "...";
			this.btnBrowseKeyword.UseVisualStyleBackColor = true;
			this.btnBrowseKeyword.Click += new System.EventHandler(this.btnBrowseKeyword_Click);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(24, 46);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(55, 13);
			this.label3.TabIndex = 3;
			this.label3.Text = "Output file";
			// 
			// btnBrowseOutput
			// 
			this.btnBrowseOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnBrowseOutput.Location = new System.Drawing.Point(382, 41);
			this.btnBrowseOutput.Name = "btnBrowseOutput";
			this.btnBrowseOutput.Size = new System.Drawing.Size(23, 23);
			this.btnBrowseOutput.TabIndex = 5;
			this.btnBrowseOutput.Text = "...";
			this.btnBrowseOutput.UseVisualStyleBackColor = true;
			this.btnBrowseOutput.Click += new System.EventHandler(this.btnBrowseOutput_Click);
			// 
			// txtOutput
			// 
			this.txtOutput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtOutput.BackColor = System.Drawing.SystemColors.Window;
			this.txtOutput.Location = new System.Drawing.Point(85, 43);
			this.txtOutput.Name = "txtOutput";
			this.txtOutput.ReadOnly = true;
			this.txtOutput.Size = new System.Drawing.Size(291, 20);
			this.txtOutput.TabIndex = 4;
			// 
			// chkPagerank
			// 
			this.chkPagerank.AutoSize = true;
			this.chkPagerank.Checked = true;
			this.chkPagerank.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkPagerank.Location = new System.Drawing.Point(135, 76);
			this.chkPagerank.Name = "chkPagerank";
			this.chkPagerank.Size = new System.Drawing.Size(72, 17);
			this.chkPagerank.TabIndex = 8;
			this.chkPagerank.Text = "&Pagerank";
			this.chkPagerank.UseVisualStyleBackColor = true;
			// 
			// ofd
			// 
			this.ofd.FileName = "openFileDialog1";
			// 
			// frmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(417, 305);
			this.Controls.Add(this.chkPagerank);
			this.Controls.Add(this.txtOutput);
			this.Controls.Add(this.btnBrowseOutput);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.btnBrowseKeyword);
			this.Controls.Add(this.tabStatus);
			this.Controls.Add(this.btnStop);
			this.Controls.Add(this.btnStart);
			this.Controls.Add(this.nudMaxLinks);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txtKeyword);
			this.Controls.Add(this.label1);
			this.Name = "frmMain";
			this.Text = "PageRank Keywords";
			this.Load += new System.EventHandler(this.frmMain_Load);
			((System.ComponentModel.ISupportInitialize)(this.nudMaxLinks)).EndInit();
			this.tabStatus.ResumeLayout(false);
			this.tabLog.ResumeLayout(false);
			this.tabLog.PerformLayout();
			this.tabWB.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtKeyword;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.NumericUpDown nudMaxLinks;
		private System.Windows.Forms.Button btnStart;
		private System.Windows.Forms.Button btnStop;
		private System.Windows.Forms.TabControl tabStatus;
		private System.Windows.Forms.TabPage tabLog;
		private System.Windows.Forms.TextBox txtLog;
		private System.Windows.Forms.TabPage tabWB;
		private System.Windows.Forms.WebBrowser brwsr;
		private System.Windows.Forms.Button btnBrowseKeyword;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button btnBrowseOutput;
		private System.Windows.Forms.TextBox txtOutput;
		private System.Windows.Forms.CheckBox chkPagerank;
		private System.Windows.Forms.OpenFileDialog ofd;
		private System.Windows.Forms.SaveFileDialog sfd;
	}
}

