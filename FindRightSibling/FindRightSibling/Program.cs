using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindRightSibling
{
    class Program
    {
        static void Main(string[] args)
        {
            Node head = new Node(1);
            head.right = new Node(3);
            head.left = new FindRightSibling.Node(2);
            head.right.right = new FindRightSibling.Node(5);
            head.left.right = new FindRightSibling.Node(4);
            Solution soln = new Solution();
            head = soln.FindRightSibling(head);
            Console.WriteLine();
        }
    }

    public class Solution
    {
        public Node FindRightSibling(Node head)
        {
            if (head == null)
                return null;

            Node current = head;
            Queue<Node> q = new Queue<Node>();

            q.Enqueue(head);
            int size = q.Count;
            while (q.Count != 0)
            {
                Node n = q.Dequeue();
                --size;

                if (n.left != null) q.Enqueue(n.left);
                if (n.right != null) q.Enqueue(n.right);

                if (size > 0)
                    n.rightSibling = q.First();
                else
                    size = q.Count;
            }
            return head;
        }
    }
    public class Node
    {
        public Node left, right;
        public Node rightSibling;
        public int value; 

        public Node() { }
        public Node(int val) { value = val; }
    }
}
