using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidateBST
{
    class Program
    {
        static void Main(string[] args)
        {
            TreeNode root = new TreeNode(2);
            root.right = new TreeNode(3);
            //root.right.right = new TreeNode(20);
            //root.right.left = new TreeNode(6);
            root.left = new TreeNode(1);

            bool check = IsValidBST(root);
            bool cc = check;
        }
        public static bool IsValidBST(TreeNode root)
        {
           
            if (root == null)
                return true;

            return RecursiveIsValidBST(root, Double.NegativeInfinity, Double.PositiveInfinity);
           
        }

        private static bool RecursiveIsValidBST(TreeNode root, double min, double max)
        {
            if (root.val <= min || root.val >= max)
                return false;
            if (root.left != null && !RecursiveIsValidBST(root.left, min, root.val))
                return false;
            if (root.right != null && !RecursiveIsValidBST(root.right, root.val, max))
                return false;
            return true;
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
