using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RansomNote
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution soln = new Solution();
            string ransomNote = "I have your pants";
            string magazine = "Time Magazine wants your appartment very much";

            bool writeNote = soln.CanWrite(ransomNote, magazine);

            Console.WriteLine();

        }
    }

    public class Solution
    {
        public bool CanWrite(string note, string magazine)
        {
            Dictionary<char, int> noteMap = new Dictionary<char, int>();
            Dictionary<char, int> magazineMap = new Dictionary<char, int>();

            foreach(var c in note.ToLower())
            {
                if (c != ' ')
                {
                    if (noteMap.ContainsKey(c))
                        noteMap[c]++;
                    else
                        noteMap.Add(c, 1);
                }
            }
            foreach (var c in magazine.ToLower())
            {
                if (c != ' ')
                {
                    if (magazineMap.ContainsKey(c))
                        magazineMap[c]++;
                    else
                        magazineMap.Add(c, 1);
                }
            }

            foreach(var k in noteMap)
            {
                if (!magazineMap.ContainsKey(k.Key))
                    return false;
                if (magazineMap[k.Key] < k.Value)
                    return false;
            }

            return true; 
        }
    }
}
