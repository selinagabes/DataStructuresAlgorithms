using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

/*
 * Gabriele, Selina 
 * Octoboer 2016
 * Given an encoded string of digits, how many ways can it de decoded
 * [A-Z]=[1-26]
 * Input: string of digits
 * Output: int number of ways to decode
 * ie "12" can be 1 and 2 or 12.. therefore it can be decoded 2 ways
 */
namespace DecodeWays
{
    class Program
    {
        static void Main(string[] args)
        {
            string digits = Console.ReadLine();
            int decodedWays = NumDecodings(digits);
        }

        public static int NumDecodings(string s)
        {
            var variations = 0;
            List<string> ls = new List<string>();
            Regex regEx = new Regex("(((1)(?=[\\d]))|((2)(?=[1-6])))");
            //variations += s.Count();
            variations += regEx.Matches(s).Count;
            foreach(Match m in regEx.Matches(s))
            {
                ls.Add(m.Value);
            }
            //TODO: not the number of letters as per
            return variations;
        }
    }
}
