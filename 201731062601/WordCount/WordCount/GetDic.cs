using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
namespace WordCount
{
    interface GetDic
     {
         Dictionary<string, int> CountLetter(string txt, int m=1);
     }
     public class countletter : GetDic
     {
         Dictionary<string, int> GetDic.CountLetter(string txt, int m=1)
         {
             Dictionary<string, int> Letter = new Dictionary<string, int>();
             int now = 0;
             string begin = "";
             bool flag = false;
             char[] symbol = { ' ', '\t', ',', '.', '?', '!', ':', ';', '\'', '\"', '\n', '{', '}', '(', ')', '+', '*', '=' };
             foreach (var i in txt)
             {
                 if (char.IsNumber(i))
                 {
                     if (begin.Length >= 4)
                     {
                         begin += i;
                         flag = true;
                         continue;
                     }
                 }
                 else if (char.IsLetter(i))
                 {
                     var le = char.ToLower(i);
                     begin += le;
                     flag = true;
                     continue;
                 }
                 else if (begin.Length == 0)
                 {
                     continue;
                 }
                 if (flag)
                 {
                     flag = false;
                     now++;
                 }
                 if (now < m)
                 {
                     begin += i;
                    continue;
                 }
                 now = 0;
               
                if (begin.Length >= 4)
                 {
                     if (Letter.ContainsKey(begin))
                         Letter[begin]++;
                     else
                         Letter.Add(begin, 1);

                 }
                 foreach (var t in symbol)
                 {
                     if (i == t)
                         begin = "";
                 }
                 begin = "";

             }
             //整理字典
             bool temp = true;
             bool va = false;
             int words = 0;
             Regex regNum = new Regex("^[0-9]");
             while (temp)
             {
                 va = false;
                 foreach (var i in Letter)
                 {
                     if (regNum.IsMatch(i.Key) || i.Key.Length <= 4)
                     {
                         Letter.Remove(i.Key);
                         va = true;
                         break;
                     }
                 }
                 temp = va;

             }
             return Letter;
         }
     }
}
