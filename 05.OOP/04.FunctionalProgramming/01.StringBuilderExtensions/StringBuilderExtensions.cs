using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _01.StringBuilderExtensions
{
    public static class StringBuilderExtensions
    {
        public static StringBuilder SubString(this StringBuilder stringBuilder, int startIndex, int length)
        {
            if (startIndex < 0)
            {
                throw new ArgumentOutOfRangeException("Start index cannot be negative!");
            }
            if (length > stringBuilder.Length - startIndex)
            {
                throw new ArgumentOutOfRangeException("Invalid length for substring!");
            }
            StringBuilder returnValue = new StringBuilder();
            string str = stringBuilder.ToString();

            for (int i = 0; i < length; i++)
            {
                returnValue.Append(str[startIndex]);
                startIndex++;
            }
            return returnValue;
        }

        public static StringBuilder RemoveText(this StringBuilder stringBuilder, string text)
        {
            // http://stackoverflow.com/questions/6275980/string-replace-by-ignoring-case
            string result = Regex.Replace(stringBuilder.ToString(), text, "", RegexOptions.IgnoreCase);
            return new StringBuilder(result);
        }

        public static StringBuilder AppendAll<T>(this StringBuilder stringBuilder, IEnumerable<T> items)
        {
            // http://www.dotnetperls.com/append
            // http://www.dotnetperls.com/string-join
            return stringBuilder.Append(string.Join("", items));
        }
    }
}
