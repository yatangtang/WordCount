using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCount
{
    interface CountLines
    {
        int countLines(string path);
    }
    public class countlines : CountLines
    {
        int CountLines.countLines(string txt)
        {
            int lines = 0;
            bool flag = true;
            foreach (var i in txt)
            {
                if (i == '\n')
                {
                    if (flag)
                    {
                        lines++;
                        flag = false;
                        continue;
                    }
                    else
                    {
                        flag = true;
                    }
                }
            }
            lines++;
            return lines;
        }
    }
}
