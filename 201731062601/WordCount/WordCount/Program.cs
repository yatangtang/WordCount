using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace WordCount
{
    public class Countword
    {
        public bool GetFile(string path, out string txt)
        {
            try
            {
                txt = System.IO.File.ReadAllText(path);
                return true;
            }
            catch (Exception e)
            {
                txt = "";
                return false;
            }
        }
        public void Anword(string txt,int m=1,int n=10, string output = "output.txt")
        {
            
            GetDic cl = new countletter();
            var word = cl.CountLetter(txt, m);
            StreamWriter sw = new StreamWriter(output);
            try
            {
                Console.SetOut(sw);
                CountChar c = new countchar();
                CountWords cw = new countwords();
                CountLines cls = new countlines();
                SortWord sort = new sortwords();
                Console.WriteLine("characters: {0}", c.countChar(txt));
                Console.WriteLine("lines: {0}", cls.countLines(txt));
                Console.WriteLine("words: {0}", cw.coutWords(word));
                sort.sortWord(txt,m,n, output = "output.txt");
            }
            catch (Exception e)
            {
                Console.WriteLine("输出文件错误！");
            }
            finally
            {
                sw.Flush();
                sw.Close();
            }

        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            string path = null;
            string output = null;
            int m = 1;
            int n = 10;

            for (int i = 0; i < args.Length; i += 2)
            {
                if (!(args.Length > i + 1))
                    break;
                if (args[i] == "-i")
                    path = args[i + 1];
                else if (args[i] == "-m")
                {
                    if (!int.TryParse(args[i + 1], out m))
                        m = 1;
                }
                else if (args[i] == "-n")
                {
                    if (!int.TryParse(args[i + 1], out n))
                        n = 10;
                }
                else if (args[i] == "-o")
                {
                    output = args[i + 1];
                }
            }
            string txt;
            SortWord sort = new sortwords();
            Countword countword = new Countword();
            CountLines c = new countlines();
            if (countword.GetFile(path, out txt))
            {
                countword.Anword(txt,m,n, output);
            }
            else
            {
                Console.WriteLine("打开文件失败");
            }
            Console.ReadLine();
        }
    }
}
