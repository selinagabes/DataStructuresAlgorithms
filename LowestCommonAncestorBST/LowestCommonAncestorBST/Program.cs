using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LowestCommonAncestorBST
{
    class Program
    {
        static void Main(string[] args)
        {
            TreeNode root = new TreeNode(-1);
            root.left = new TreeNode(-2);
            root.right = new TreeNode(0);
            root.left.left = null;
            root.left.right = new TreeNode(2);

            //root.left = new TreeNode(2);
            //TreeNode p1 = root.left;
            //root.left.left = new TreeNode(0);
            //root.left.right = new TreeNode(4);
            //TreeNode q2 = root.left.right;
            //root.left.right.left = new TreeNode(3);
            //root.left.right.right = new TreeNode(5);
            //root.right = new TreeNode(8);
            //TreeNode q1 = root.right;
            //root.right.left = new TreeNode(7);
            //root.right.right = new TreeNode(9);

            Solution soln = new Solution();
            TreeNode ancestor1 = soln.LowestCommonAncestor(root, root.left.right, root.right);

            Console.Read();
        }
    }
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }
    public class Solution
    {
        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            if (root == null)
                return root;

            if (p.Equals(root) || q.Equals(root)
                || ((root.left.Equals(p) && root.right.Equals(q)) ||
                     (root.left.Equals(q) && root.right.Equals(p))
                   ))
                return root;

            if (p.val < root.val && q.val < root.val)
                return root.left != null ? LowestCommonAncestor(root.left, p, q) : root;
            else if (q.val > root.val && p.val > root.val)
                return root.right != null ? LowestCommonAncestor(root.right, p, q) : root;
            else
                return root;

           

        }
    }
}
