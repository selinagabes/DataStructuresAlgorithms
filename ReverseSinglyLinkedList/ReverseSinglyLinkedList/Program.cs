using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseSinglyLinkedList
{
    class Program
    {
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }
        static void Main(string[] args)
        {
            ListNode head = new ListNode(1);
            head.next = new ListNode(5);
            head.next.next = new ListNode(3);
            head = ReverseList(head);
            Console.ReadLine();
        }

        public static ListNode ReverseList(ListNode head)
        {
            if (head == null || head.next == null)      //if there is0 or only 1 
                return head; 

            
            ListNode previous = null;
            ListNode current = head;
            while (current != null)
            {
                    ListNode ahead = current.next;
                current.next = previous;
                previous = current;
                current = ahead;

            }
            head = previous;
            return head;
        }
    }
}
