using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissingStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            long[] coins = new long[] { 2, 5, 8, 3 };

            string[] sub = buildSubsequences("ab");
        }

        static string[] buildSubsequences(string s)
        {
            /*byte[] stringAsBytes = new byte[s.Count()];
            char[] _c = s.ToCharArray();
            for(int i =0 i< stringAsBytes.Length; i++)
                stringAsBytes[i]=0;*/

            if (s.Length == 2)
            {
                char[] _c = s.ToCharArray();
                string _s = new string(new[] { _c[1], _c[0] });
                return new[] { s, _s, _c[1].ToString(), _c[0].ToString() };
            }
            List<string> res = new List<string>();

            string[] subSeq = buildSubsequences(s.Substring(1));
            char f = s[0];
            foreach (string sub in subSeq.Select(x => f.ToString() + x))
            {
                res.Add(sub);
                char[] temp = sub.ToCharArray();
                for (int i = 0; i < sub.Length - 1; i++)
                {
                    char swap = temp[i];
                    temp[i] = temp[i + 1];
                    temp[i + 1] = swap;
                    string result = new string(temp);
                    res.Add(result);
                }
            }

            return res.ToArray();
        }

        private static void maxStairs(long[] coins)
        {
          int i = 0;         
            int steps = 1;
            int count = 0;
            Dictionary<int, int> coinsStairs = new Dictionary<int, int>();

          while(coins[i] >= 0 && i < coins.Count())
          {
                if (coins[i] - steps >= 0)
                {
                    coins[i] = coins[i] - steps;
                    count++;
                    steps++;
                }else
                {
                    Console.WriteLine("{0}", count);
                    
                    i++;
                    steps = 1;
                    count = 0;
                }
                if (i >= coins.Count())
                    return;
            }
        }

        static string[] missingWords(string s, string t)
        {
            string[] allWords = System.Text.RegularExpressions.Regex.Split(s, @"\W+");
            string[] searchWords = System.Text.RegularExpressions.Regex.Split(t, @"\W+");
            string[] missingWs = new string[allWords.Count() - searchWords.Count()];
            if (allWords.Any(x => !searchWords.Contains(x)))
                missingWs = allWords.Where(x => !searchWords.Contains(x)).ToArray();
            
            return missingWs;

        }

    }
}
