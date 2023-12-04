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
