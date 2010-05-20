// Originally by Miroslav Stampar (miroslav.stampar(at)gmail.com)
// Modified by hussainweb@gmail.com
using System;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;

namespace GooglePR
{
	class Pagerank
	{
		#region Constant

		private const UInt32 GOOGLE_MAGIC = 0xE6359A60;

		#endregion

		#region Hashing functions

		private static void _mix(ref UInt32 a, ref UInt32 b, ref UInt32 c)
		{
			a -= b; a -= c; a ^= c >> 13;
			b -= c; b -= a; b ^= a << 8;
			c -= a; c -= b; c ^= b >> 13;
			a -= b; a -= c; a ^= c >> 12;
			b -= c; b -= a; b ^= a << 16;
			c -= a; c -= b; c ^= b >> 5;
			a -= b; a -= c; a ^= c >> 3;
			b -= c; b -= a; b ^= a << 10;
			c -= a; c -= b; c ^= b >> 15;
		}

		public static string GoogleCH(string url)
		{
			url = string.Format("info:{0}", url);

			var length = url.Length;

			UInt32 a, b;
			UInt32 c = GOOGLE_MAGIC;

			var k = 0;
			var len = length;

			a = b = 0x9E3779B9;

			while (len >= 12)
			{
				a += (UInt32)(url[k + 0] + (url[k + 1] << 8) + (url[k + 2] << 16) + (url[k + 3] << 24));
				b += (UInt32)(url[k + 4] + (url[k + 5] << 8) + (url[k + 6] << 16) + (url[k + 7] << 24));
				c += (UInt32)(url[k + 8] + (url[k + 9] << 8) + (url[k + 10] << 16) + (url[k + 11] << 24));
				_mix(ref a, ref b, ref c);
				k += 12;
				len -= 12;
			}
			c += (UInt32)length;

			switch (len)  /* all the case statements fall through */
			{
				case 11:
					c += (UInt32)(url[k + 10] << 24);
					goto case 10;
				case 10:
					c += (UInt32)(url[k + 9] << 16);
					goto case 9;
				case 9:
					c += (UInt32)(url[k + 8] << 8);
					goto case 8;
				/* the first byte of c is reserved for the length */
				case 8:
					b += (UInt32)(url[k + 7] << 24);
					goto case 7;
				case 7:
					b += (UInt32)(url[k + 6] << 16);
					goto case 6;
				case 6:
					b += (UInt32)(url[k + 5] << 8);
					goto case 5;
				case 5:
					b += (UInt32)(url[k + 4]);
					goto case 4;
				case 4:
					a += (UInt32)(url[k + 3] << 24);
					goto case 3;
				case 3:
					a += (UInt32)(url[k + 2] << 16);
					goto case 2;
				case 2:
					a += (UInt32)(url[k + 1] << 8);
					goto case 1;
				case 1:
					a += (UInt32)(url[k + 0]);
					break;
				default:
					break;
				/* case 0: nothing left to add */
			}

			_mix(ref a, ref b, ref c);

			return string.Format("6{0}", c);
		}

		#endregion

		#region Get method

		public static int Get(string url)
		{
			var checksum = GoogleCH(url);
			var query = string.Format("http://www.google.com/search?client=navclient-auto&ch={0}&features=Rank&q=info:{1}", checksum, System.Web.HttpUtility.UrlEncode(url));

			try
			{
				var request = WebRequest.Create(query);
				var response = new StreamReader(request.GetResponse().GetResponseStream()).ReadToEnd();

				return (response.Length != 0) ? int.Parse(Regex.Match(response, "Rank_1:[0-9]:([0-9]+)").Groups[1].Value) : -1;
			}
			catch (Exception)
			{
				return -1;
			}
		}

		#endregion
	}
}