using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelSheetColumnNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution soln = new Solution();
            string title = "AA";
            int number = soln.TitleToNumber(title);
            Console.WriteLine(number);
            Console.ReadLine();
        }
    }
    public class Solution
    {
        public int TitleToNumber(string s)
        {
            char[] title = s.ToCharArray();
            int number = 0; 

            for(int i = title.Count() -1; i >= 0; --i)
            {
                number += (title[i] - 64) * (int)Math.Pow(26, (double)((title.Count()-1) - i));
            }
            return number;
        }
    }
}
