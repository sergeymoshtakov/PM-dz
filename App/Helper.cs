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
            return input.Substring(0, len-3) + "...";
        }

        public String Finalize(String input)
        {
            return input.Substring(input.Length - 1) == "." ? input : input + ".";
        }

        public string CombineUrl(params String[] patrs)
        {
            string result = "";
            int i = 0;
            while(i < patrs.Length)
            {
                result += patrs[i].Replace("/","") == ".." ? "" : "/" + patrs[i].Replace("/", "");
                i++;
            }
            return result;
        }
    }
}
