using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCount
{
    interface CountWords
    {
        int coutWords(Dictionary<string, int> dic);
    }
    public class countwords : CountWords
    {
        int CountWords.coutWords(Dictionary<string, int> dic)
        {
            int words = 0;
            foreach (var i in dic)
            {
                words += i.Value;
            }
            return words;
        }

    }
}
