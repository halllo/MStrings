using System;
using System.Text;

namespace MStrings
{
    public static class StringExtensions
    {
        public static byte[] ToAscii(this string s)
        {
            byte[] retval = new byte[s.Length];
            for (int ix = 0; ix < s.Length; ++ix)
            {
                char ch = s[ix];
                if (ch <= 0x7f) retval[ix] = (byte)ch;
                else retval[ix] = (byte)'?';
            }
            return retval;
        }

        public static string Base64ize(this string original)
        {
            return Convert.ToBase64String(
                Encoding.UTF8.GetBytes(original));
        }

        public static string UnBase64ize(this string b64)
        {
            byte[] orgBytes = Convert.FromBase64String(b64);
            return Encoding.UTF8.GetString(orgBytes, 0, orgBytes.Length);
        }

        public static string UnWebify(this string s)
        {
            var exp = ContentScraper.For(s)
                .Replace("<.*?>", "")
                .Replace("\r", "")
                .Replace("\n", "")
                .Replace("&quot;", "\"")
                .Replace("&nbsp;", "")
                .Until("<");
            return exp.Result.Trim();
        }

        public static string NormWhiteSpaces(this string s)
        {
            string normedDesc = s;
            while (normedDesc.Contains("  ")) normedDesc = normedDesc.Replace("  ", " ");
            return normedDesc.Trim();
        }
    }
}
