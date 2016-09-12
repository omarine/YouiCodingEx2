using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace YouiCodingEx
{
    public static class TextTool
    {
        /// <summary>
        /// Count occurrences of strings.
        /// </summary>
        public static int CountStringOccurrences(string text, List<string> list)
        {
            // Loop through all instances of the string 'text'.
            return list.Where(x => x.Equals(text)).Count();
        }

        public static int GetStreetNumber(string number)
        {
            var result = Regex.Split(number, @"\D+");

            int streetNumber;
            if (int.TryParse(result[0], out streetNumber))
            {

            }

            return streetNumber;

        }

        public static string GetStreetName(string name)
        {
            return Regex.Replace(name, @"[\d-]", string.Empty).TrimStart();
        }






    }
}
