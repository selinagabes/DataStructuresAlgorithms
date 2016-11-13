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
            int test = 100;
            string testWord = soln.NumberToWords(test);
            Console.WriteLine(testWord);
            Console.Read();
        }
    }

    public class Solution
    {
        // max 2 147 483 647
        public string NumberToWords(int num)
        {
            if (num == 0) return "Zero";
            Dictionary<int, string> intToWord = GetDictionary();
            if (intToWord.ContainsKey(num))
            {
                if (num > 10 && num % 100 == 0)
                    return "One " + intToWord[num];
                else
                    return intToWord[num];
            }
            int numToWord = num;

            int currentDig;
            List<string> returnStrings = new List<string>();
           
            for (int i = 1; i <= 4; i++)
            {
                if (numToWord > 0)//100 blocks
                {

                    currentDig = numToWord % 100;
                    if (currentDig != 0)
                    {
                        if (currentDig < 20)
                        {
                            returnStrings.Add(intToWord[currentDig]);

                        }
                        else
                        {
                            returnStrings.Add(intToWord[currentDig % 10]);
                            returnStrings.Add(intToWord[currentDig - (currentDig % 10)]);

                        }
                    }
                    numToWord -= currentDig;
                    if (numToWord > 0)
                    {
                        returnStrings.Add(intToWord[100]);
                        numToWord /= 100;
                        currentDig = numToWord % 10;
                        returnStrings.Add(intToWord[currentDig]);
                        numToWord -= currentDig;
                        numToWord /= 10;
                    }

                }
                if (numToWord <= 0)
                    break;
                returnStrings.Add(intToWord[(int)Math.Pow(10, (i * 3))]);

            }

            string result = "";
            foreach (string s in returnStrings)
            {
                result = s + " " + result;
            }

            return result.Trim();
        }

        public Dictionary<int, string> GetDictionary()
        {

            Dictionary<int, string> prefixes = new Dictionary<int, string>();
            prefixes.Add(2, "Twe");
            prefixes.Add(3, "Thir");
            prefixes.Add(5, "Fif");
            prefixes.Add(4, "For");
            prefixes.Add(8, "Eigh");
            Dictionary<int, string> postfixes = new Dictionary<int, string>();
            postfixes.Add(1, "teen");
            postfixes.Add(10, "ty");


            Dictionary<int, string> intToWord = new Dictionary<int, string>();
            intToWord.Add(0, "");
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
            intToWord.Add(40, prefixes[4] + postfixes[10]);
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
