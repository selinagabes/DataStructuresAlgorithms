using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreePathSum
{
    class Program
    {
        static void Main(string[] args)
        {
            //TreeNode root = new TreeNode(5);
            //root.left = new TreeNode(4);
            //root.left.left = new TreeNode(11);
            //root.left.left.left = new TreeNode(7);
            //root.left.left.right = new TreeNode(2);
            //root.right = new TreeNode(8);
            //root.right.left = new TreeNode(13);
            //root.right.right = new TreeNode(4);
            //root.right.right.right = new TreeNode(1);

            TreeNode root = new TreeNode(-2);
            root.left = null;
            root.right = new TreeNode(-3);

            bool hasPathSum = HasPathSum(root, -5);
            bool hps = hasPathSum;
        }

        public static bool HasPathSum(TreeNode root, int sum)
        {

            if (root == null)
            {
                return false;
            }
            if (root.left == null && root.right == null)
            {
                return sum - root.val == 0;
            }

            return HasPathSum(root.left, sum - root.val) || HasPathSum(root.right, sum - root.val);
        }
    }

    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }
}
