using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCount
{
    interface SortWord
    {
        void sortWord(string txt,int m,int n ,string output = "output.txt");
    }
    public class sortwords : SortWord
    {
        void SortWord.sortWord(string txt,int m=1,int n=10, string output = "output.txt")
        {
           
            GetDic cl = new countletter();
            var word = cl.CountLetter(txt, m);
            var list = word.ToList();
            list.Sort((x, y) =>
            {
                if (x.Value == y.Value)
                    return x.Key.CompareTo(y.Key);
                return -x.Value.CompareTo(y.Value);
            });
            for (int i = 0; i < n; i++)
            {
                if (list.Count >= i + 1)
                {
                    Console.WriteLine("{0}: {1}", list[i].Key, list[i].Value);
                }

            }
        }
    }
}
