using System;

namespace Recurs_LinkedList
{

    class Node {
        private int data;
        private Node next;

        public int Data { get { return data; } }
        public Node Next { get { return next; } set { next = value; } }

        public Node(int new_data)
        {
            data = new_data;
            next = null;
        }
    }

    class RLinked_List
    {
        public Node head;
        public RLinked_List() { }

        public RLinked_List(int data)
        {
            Node temp = new Node(data);
            this.head = temp;
        }

        public RLinked_List(RLinked_List Same)
        {
            head = Same.head;
        }

        public void insertend(int data)
        {
            Node temp = this.head;
            Node newnode = new Node(data);
            if (this.head == null)
            {
                this.head = newnode;
                return;
            }
            temp.Next=recinsert(newnode,temp);
        }

        public Node recinsert(Node newnode, Node temp)
        {
            if (temp == null)
            {
                temp = newnode;
                return temp;
            }
            else
            {
              return recinsert(newnode, temp.Next);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            RLinked_List List_A = new RLinked_List();
            List_A.insertend(34);
            List_A.insertend(56);
            List_A.insertend(3);


        }
    }
}
