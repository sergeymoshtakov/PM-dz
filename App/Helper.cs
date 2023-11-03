using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    public class Helper
    {
        public String Ellipsis(string input, int len)
        {
            return input.Substring(0, len-3) + "...";
        }

        public String Finalize(String input)
        {
            return input.Substring(input.Length - 1) == "." ? input : input + ".";
        }
    }
}
