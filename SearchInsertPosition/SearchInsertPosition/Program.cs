using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchInsertPosition
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 1, 3, 5, 6 };

            int index = SearchInsert(nums, 5);
            Console.WriteLine(index);
            index = SearchInsert(nums, 2);
            Console.WriteLine(index);
            index = SearchInsert(nums, 7);
            Console.WriteLine(index);
            index = SearchInsert(nums, 0);
            Console.WriteLine(index);
            
            Console.ReadLine();
        }

        public static int SearchInsert(int[] nums, int target)
        {
            int i = 0;
            while (nums[i] <= target)
            {
                if (nums[i] == target)
                    return i;
                if (nums[i] > target)
                    return i;
                if (i == nums.Count() - 1)
                    return i + 1;
                ++i;
            }
            return i;
        }
    }
}
