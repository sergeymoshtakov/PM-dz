using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    public class Helper
    {
        public String Ellipsis(string input, int len)
        {
            if (input == null) throw new ArgumentNullException("Null detected of parameter: " + nameof(input));
            if (len < 3)
            {
                throw new ArgumentException("Argument 'len' could not be less than 3");
            }
            if (input.Length < len) {
                throw new ArgumentException("Argument 'len' could not be greater than input length");
            }
            return input.Substring(0, len - 3) + "...";
        }

        public String Finalize(String input)
        {
            return input.Substring(input.Length - 1) == "." ? input : input + ".";
        }

        public string CombineUrl(params String[] patrs)
        {
            try
            {
                string result = "";
                int i = 0;
                bool wasNull = false;
                while (i < patrs.Length)
                {
                    if (patrs[i] == null)
                    {
                        i++;
                        wasNull = true;
                        continue;
                    }
                    if (wasNull)
                    {
                        throw new ArgumentException("Not null argument after null one");
                    }
                    result += patrs[i].Replace("/", "") == ".." ? "" : "/" + patrs[i].Replace("/", "");
                    i++;
                }
                if (result.Length == 0)
                {
                    throw new ArgumentException("Arguments are null!");
                }
                return result;
            }
            catch (NullReferenceException)
            {
                throw new ArgumentException("Arguments are null!");
            }
        }
    }
}
