using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegerToEnglishWord
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution soln = new Solution();
            int test = 2147483647;
            string testWord = soln.NumberToWords(test);
            Console.Read();
        }
    }

    public class Solution
    {
        // max 2 147 483 647
        public string NumberToWords(int num)
        {
            Dictionary<int, string> intToWord = GetDictionary();
            int numToWord = num;
            int digCount = 0;
            int currentDig;
            List<string> returnStrings = new List<string>();
            while (numToWord > 0)
            {
                
                digCount++;
                currentDig = numToWord % (int)Math.Pow(10, digCount==3?digCount-2:digCount);
                returnStrings.Add(intToWord[currentDig]);
                numToWord -= currentDig;
                if (digCount == 2)
                {
                    returnStrings.Add(intToWord[100]);
                    numToWord /= 100;
                }if(digCount == 3)
                {
                    if(returnStrings.Count < 5)
                        returnStrings.Add(intToWord[1000]);
                    else if (5 < returnStrings.Count && returnStrings.Count < 10)
                        returnStrings.Add(intToWord[1000000]);
                    if (10 < returnStrings.Count && returnStrings.Count < 15)
                        returnStrings.Add(intToWord[1000000000]);
                    numToWord /= 10;
                    digCount = 0;
                }

            }
            string result = "";
            foreach(string s in returnStrings)
            {
                result = s +" "+ result; 
            }

            return result;
        }

        public Dictionary<int, string> GetDictionary()
        {

            Dictionary<int, string> prefixes = new Dictionary<int, string>();
            prefixes.Add(2, "Twe");
            prefixes.Add(3, "Thir");
            prefixes.Add(5, "Fif");
            prefixes.Add(8, "Eigh");
            Dictionary<int, string> postfixes = new Dictionary<int, string>();
            postfixes.Add(1, "teen");
            postfixes.Add(10, "ty");

            Dictionary<int, string> quantifiers = new Dictionary<int, string>();
            quantifiers.Add(100, "Hundred");
            quantifiers.Add(1000, "Thousand");
            quantifiers.Add(1000000, "Million");

            Dictionary<int, string> intToWord = new Dictionary<int, string>();
            intToWord.Add(1, "One");
            intToWord.Add(2, "Two");
            intToWord.Add(3, "Three");
            intToWord.Add(4, "Four");
            intToWord.Add(5, "Five");
            intToWord.Add(6, "Six");
            intToWord.Add(7, "Seven");
            intToWord.Add(8, "Eight");
            intToWord.Add(9, "Nine");
            intToWord.Add(10, "Ten");
            intToWord.Add(11, "Eleven");
            intToWord.Add(12, prefixes[2] + "lve");
            intToWord.Add(13, prefixes[3] + postfixes[1]);
            intToWord.Add(14, intToWord[4] + postfixes[1]);
            intToWord.Add(15, prefixes[5] + postfixes[1]);
            intToWord.Add(16, intToWord[6] + postfixes[1]);
            intToWord.Add(17, intToWord[7] + postfixes[1]);
            intToWord.Add(18, prefixes[8] + postfixes[1]);
            intToWord.Add(19, intToWord[9] + postfixes[1]);
            intToWord.Add(20, prefixes[2] + "n" + postfixes[10]);
            intToWord.Add(30, prefixes[3] + postfixes[10]);
            intToWord.Add(40, intToWord[4] + postfixes[10]);
            intToWord.Add(50, prefixes[5] + postfixes[10]);
            intToWord.Add(60, intToWord[6] + postfixes[10]);
            intToWord.Add(70, intToWord[7] + postfixes[10]);
            intToWord.Add(80, prefixes[8] + postfixes[10]);
            intToWord.Add(90, intToWord[9] + postfixes[10]);
            intToWord.Add(100, "Hundred");
            intToWord.Add(1000, "Thousand");
            intToWord.Add(1000000, "Million");
            intToWord.Add(1000000000, "Billion");

            return intToWord;
        }
    }
}
