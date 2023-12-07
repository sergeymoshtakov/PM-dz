using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace App
{
    public class Helper
    {
        // method that changes <, >, & to &lt;, &gt;, &amp;
        public String UnitTest(string input, Dictionary<string, string>? map = null)
        {
            if (input == null) throw new ArgumentNullException("HTML should not be null"); // checks if input is not null
            if (input.Length == 0) // checks in input string is not empty
            {
                throw new ArgumentException("HTML must not be empty");
            }
            if (!IsHtmlValid(input)) // checks if there is a valid html string
            {
                throw new ArgumentException("This should be a correct html file");
            }
            Dictionary<string, string> htmlSpecSymbols = map ?? new Dictionary<string, string> { { "&", "&amp;" }, { "<", "&lt;" }, { ">", "&gt;" } };
            var escapedHtml = new StringBuilder();
            foreach (var c in input)
                escapedHtml.Append(htmlSpecSymbols.TryGetValue(c.ToString(), out var replacement) ? replacement : c.ToString());

            return escapedHtml.ToString();
        }
        // checks if there is a attributes in the html tag
        public bool ContainsAttributes(String html)
        {
            string pattern = @"\w+\s+[^=]*(\w+=[^>]+)+>";
            Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
            return regex.IsMatch(html);
        }
        // checks if it is a valid html string
        private bool IsHtmlValid(string input)
        {
            int openTagCount = 0;
            foreach (char c in input)
            {
                if (c == '<')
                {
                    openTagCount++;
                }
                else if (c == '>')
                {
                    if (openTagCount == 0)
                    {
                        return false;
                    }
                    openTagCount--;
                }
            }

            return openTagCount == 0;
        }

        public String Ellipsis(string input, int len)
        {
            if (input == null) throw new ArgumentNullException("Null detected of parameter: " + nameof(input)); //check if null parameter
            if (len < 3) // check if argument len is lower than 3
            {
                throw new ArgumentException("Argument 'len' could not be less than 3");
            }
            if (input.Length < len) { // check if argument len is grater than input length
                throw new ArgumentException("Argument 'len' could not be greater than input length");
            }
            return input.Substring(0, len - 3) + "...";
        }
        // adds a dot in the end if it doesn't allready there
        public String Finalize(String input)
        {
            return input.Substring(input.Length - 1) == "." ? input : input + ".";
        }
        // combines a url from different parts
        public string CombineUrl(params String[] patrs)
        {
            try
            {
                string result = ""; // initial string
                int i = 0;
                bool wasNull = false; // checks if there was a null value before
                while (i < patrs.Length)
                {
                    if (patrs[i] == null) // checks if current value is null
                    {
                        i++;
                        wasNull = true; // sets that there was a null value before
                        continue; // goes to the next element
                        // all other null values after this null value will be here
                    }
                    if (wasNull) // not null value after null value
                    {
                        throw new ArgumentException("Not null argument after null one"); // generates exception if current value
                                                                                         // is not null but there was a null value before
                    }
                    result += patrs[i].Replace("/", "") == ".." ? "" : "/" + patrs[i].Replace("/", ""); //replaces more /// and adds / where needed
                                                                                                        //checks if there is .. and skips it
                    i++;
                }
                if (result.Length == 0)
                {
                    throw new ArgumentException("Arguments are null!"); // exception if all arguments were null
                }
                return result;
            }
            catch (NullReferenceException)
            {
                throw new ArgumentException("Arguments are null!"); // handles the NullReferenceException and throws exception that
                                                                    // all arguments are null
            }
        }
    }
}
