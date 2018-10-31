using System;

//Write an algorithm to determine if a linkedlist is circular. 
//FOLLOW UP: Determine where the circle meets.

namespace LinkedList2
{
    public class Node
    {
        public Node next;
        public int data;

        public Node()
        {
            next = null;
        }
        public Node(int d)
        {
            data = d;
            next = null;
        }
    }

    public class MyLList
    {
        Node head;

        public MyLList()
        {
            head = null;
        }

        public Node AddNodeTailCircle(int d, Node ncircl)
        {
            Node node = new Node(d);
            if (head == null)
            {
                head = node;
            }
            else
            {
                Node cur = head;
                while (cur.next != null)
                {
                    cur = cur.next;
                }
                cur.next = node;
            }

            if (ncircl != null)
            {
                node.next = ncircl;
            }

            return node;
        }

        public bool IsCircular()
        {
            if (head == null) return false;
            Node slow = head, fast = head;
            int flag = 0;

            while (flag == 0 && slow != null && fast != null)
            {
                slow = slow.next;
                fast = fast.next.next;
                if (slow == fast)
                    flag = 1;
            }
            if (flag == 1) return true;
            return false;
        }

        public int FindLoopStart()
        {
            if (head == null) return 0;
            Node slow = head, fast = head;
            while (slow != null && fast != null)
            {
                slow = slow.next;
                fast = fast.next.next;
                if (slow == fast) //has a loop
                {
                    slow = head;
                    while (slow != fast)
                    {
                        slow = slow.next;
                        fast = fast.next;
                    }
                    return slow.data;
                }
            }
            return 0;
        }

        public void printAllNodes()
        {
            Node cur = head;
            int i = 0;
            while (i <= 1)
            {
                Console.WriteLine(cur.data);
                cur = cur.next;
                i++;
            }
            if (cur != null)
                Console.WriteLine(cur.data);
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            MyLList list = new MyLList();
            Node node = null;
            list.AddNodeTailCircle(1, null);
            list.AddNodeTailCircle(2, null);
            node = list.AddNodeTailCircle(3, null);
            list.AddNodeTailCircle(4, null);
            //list.AddNodeTailCircle(5, null);
            list.AddNodeTailCircle(6, null);
            list.AddNodeTailCircle(7, null);
            list.AddNodeTailCircle(8, node);

            list.printAllNodes();
            
            bool res = list.IsCircular();
            if (res)
                Console.WriteLine("A linked list is circular");
            else
                Console.WriteLine("A linked list is NOT circular");

            int data = list.FindLoopStart();
            if (data > 0)
                Console.WriteLine("The circle meets in the node.data = " + data);
            else
                Console.WriteLine("There is NO meeting");

        }
    }
}
