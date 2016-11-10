using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductExceptSelf
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] test = { 1, 2, 3, 4 };
            int[] productXSelf = ProductExceptSelf(test);
        }
        public static int[] ProductExceptSelf(int[] nums)
        {
            int[] output = new int[nums.Count()];
            output[0] = 1;          //to be used for product.

            //product all the way to the end, and then go back aagain 
            for(int i = 1; i <nums.Count(); i++)
            {
                output[i] = output[i - 1] * nums[i - 1];
                
            }// the last element will be the sum of them all excluding itself

           //start at the second to last element, and work backwards now
           for(int i = nums.Count() - 2; i >0; --i)
            {
                output[i] *= output[0] * nums[i + 1];
                output[0] *= nums[i + 1];
            }
            output[0] *= nums[1];

            return output;
        }
    }
}
