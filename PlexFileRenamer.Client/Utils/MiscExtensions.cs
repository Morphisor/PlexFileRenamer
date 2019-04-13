using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlexFileRenamer.Client.Utils
{
    public static class MiscExtensions
    {
        public static string Ellipsis(this string text, int characterNumber)
        {
            if (text == null) return string.Empty;

            var length = text.Length < characterNumber ? text.Length : characterNumber;
            return text.Substring(0, length) + "...";
        }
    }
}
