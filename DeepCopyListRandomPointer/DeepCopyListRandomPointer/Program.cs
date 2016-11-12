using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeepCopyListRandomPointer
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
    public class Solution
    {
        public RandomListNode CopyRandomList(RandomListNode head)
        {
            if (head == null)
                return null;

            Dictionary<RandomListNode, RandomListNode> map = new Dictionary<RandomListNode, RandomListNode>();
            RandomListNode root = new RandomListNode(head.label);       //new list

            RandomListNode curr = head;
            RandomListNode newCurr = root;
            map.Add(curr, newCurr);                                     //add reference to heads in the table

            curr = curr.next;                                           //go to the next one
            while(curr != null)
            {
                RandomListNode node = new RandomListNode(curr.label);
                map.Add(curr, node);
                newCurr.next = node;
                newCurr = node;
                curr = curr.next;
            }                                                            //keep all the references
            //now get all the references and put them into a list

            curr = head;
            newCurr = root; 
            while(curr != null)
            {
                if (curr.random != null)
                    newCurr.random = map[curr.random];
                else
                    newCurr.random = null;

                curr = curr.next;
                newCurr = newCurr.next;
            }

            return root;
        }
    }

    public class RandomListNode
    {
        public int label;
        public RandomListNode next, random;
        public RandomListNode(int x) { this.label = x; }
    };
}
