using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LongestPalindromeSequence
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution soln = new Solution();
            string test = "alkmsnjggabshhwutokkslamgnncjdlaaaplkgnnnkfdjs";
            string result = soln.PalindromeSequence(test);

            Console.ReadLine();
        }
    }

    public class Solution
    {
        public string PalindromeSequence(string s)
        {
            Dictionary<char, int> palindrome = new Dictionary<char, int>(); 

            foreach(char c in s)
            {
                if(palindrome.ContainsKey(c))
                {
                    ++palindrome[c];
                }else
                {
                    palindrome.Add(c, 1);
                }
            }
            char oddChar = new char();
            int oddOccurrence = 0; ;

            foreach(var k in palindrome)
            {
                if(palindrome[k.Key]%2 != 0 && palindrome[k.Key] > oddOccurrence)
                {
                    oddChar = k.Key;
                    oddOccurrence = k.Value;
                }
            }
            string sB = "";
            for (int i = 0; i < oddOccurrence; i++)
                sB+=oddChar.ToString();

            foreach(var k in palindrome)
            {
                if(palindrome[k.Key]%2 == 0)
                {
                    int temp = palindrome[k.Key];
                    while (temp > 0)
                    {
                        sB = k.Key.ToString() + sB + k.Key.ToString();
                        temp -= 2;
                    }
                }
            }
            return sB;
        }
    }
}
