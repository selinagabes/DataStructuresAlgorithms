using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace IsPalindrom
{
    class Program
    {
        static void Main(string[] args)
        {
            bool palindrome1 = IsPalindrome("A man, a plan, a canal: Panama");
            bool palindrome2 = IsPalindrome("race a car");
        }

        public static bool IsPalindrome(string s)
        {
            Regex regex = new Regex("[^a-zA-Z0-9]");
            char[] charArray = regex.Replace(s.ToLower(), "").ToCharArray();
            int i = 0; 
            int j = charArray.Count()-1;
            while(i <= j)
            {
                if (charArray[i] != charArray[j])
                    return false;
                i++;
                j--;
            }

            return true;
        }
    }
}
