using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
namespace WordCount
{
    interface CountChar
    {
        int countChar(string txt);
    }
    public class countchar : CountChar
    {
        int CountChar.countChar(string txt)
        {
            int number = 0;
            number = Regex.Matches(txt, @"\f\n\r\t").Count;
            foreach (var i in txt)
            {
                if (i >= 32 && i < 126)
                {
                    number++;
                }
            }
            return number;
        }

    }
}
