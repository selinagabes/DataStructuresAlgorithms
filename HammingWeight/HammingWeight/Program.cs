using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HammingWeight
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            int hammingW = HammingWeight((uint)input);
            Console.WriteLine(hammingW);
            Console.ReadLine();
        }
        public static int HammingWeight(uint n)
        {
           
            int sum = 0;
            int value = (int)n;
            while (value > 0)
            {
                sum += value & 0x01;
                value >>= 1;
            }
            return sum;
        }
    }
}
