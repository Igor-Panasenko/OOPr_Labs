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
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
