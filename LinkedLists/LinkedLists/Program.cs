using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedLists
{
    public class Node
    {
        int data;
        Node next = null;
        Node prev = null;
        public Node(int d)
        {
            this.data = d;
            this.prev = null;
        }

        public void AppendToTail(Node head, int d)
        {

            Node end = new Node(d);
            Node curr = head;
            while (curr.next != null)
            {
                curr.next.prev = curr;
                curr = curr.next;
            }
            end.prev = curr;
            curr.next = end;

        }

        public Node AppendToFront(int d)
        {
            Node front = new Node(d);
            Node curr = this;
            curr.prev = front;
            front.next = curr;

            return front;
        }

       public Node Partition(Node n, int pivot) {
            Node head = n;
            Node current = n;
            Node tail = n; 
            while(current != null)
            {
                if(current.data >= pivot)
                {
                    current.prev = tail;
                    tail.next = current;
                    
                    current = current.next;
                    tail = tail.next;
                    tail.next = null;
                }else
                {
                    Node temp = current.next;
                    if (head != current)
                    {
                        current.next = head;                        
                    }
                    head.prev = current;
                    current.prev = null;
                    head = current;
                    current = temp;
                }
            }

            return head;

        }
    }

    class Program
    {

        static void Main(string[] args)
        { 
           
            Node head = new Node(3);
            head.AppendToTail(head, 5);
            head.AppendToTail(head, 8);
            head.AppendToTail(head, 10);
            head.AppendToTail(head, 5);
            head.AppendToTail(head, 1);
            head.AppendToTail(head, 2);

            head = head.Partition(head, 5);
            Console.ReadLine();
            

        }
    }
}
