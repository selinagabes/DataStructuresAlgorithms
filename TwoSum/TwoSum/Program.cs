﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwoSum
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution soln = new Solution();
            int[] test = { 230, 863, 916, 585, 981, 404, 316, 785, 88, 12, 70, 435, 384, 778, 887, 755, 740, 337, 86, 92, 325, 422, 815, 650, 920, 125, 277, 336, 221, 847, 168, 23, 677, 61, 400, 136, 874, 363, 394, 199, 863, 997, 794, 587, 124, 321, 212, 957, 764, 173, 314, 422, 927, 783, 930, 282, 306, 506, 44, 926, 691, 568, 68, 730, 933, 737, 531, 180, 414, 751, 28, 546, 60, 371, 493, 370, 527, 387, 43, 541, 13, 457, 328, 227, 652, 365, 430, 803, 59, 858, 538, 427, 583, 368, 375, 173, 809, 896, 370, 789 };

            int targ = 542;
            int[] result = soln.TwoSum(test, targ);
        }
    }
    public class Solution
    {
        public int[] TwoSum(int[] nums, int target)
        {
            int subtraction = 0;
            Dictionary<int, int> diffIndex = new Dictionary<int, int>();
            int[] result = new int[2];

            for (int i = 0; i < nums.Count(); i++)
            {
                if (diffIndex.ContainsKey(nums[i]))
                {
                    int index = diffIndex[nums[i]];
                    result[0] = index;
                    result[1] = i;
                    return result;
                }
                else
                {
                    if(!diffIndex.ContainsKey(target - nums[i]))
                        diffIndex.Add(target - nums[i], i);
                }
            }

            return null;//no result
        }
    }
}