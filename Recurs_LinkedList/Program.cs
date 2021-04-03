using System;

namespace Recurs_LinkedList
{

    class Node {
        private int data;
        private Node next;

        public int Data { get { return data; } }
        public Node Next { get { return next; } set { next = value; } }
    }

    class RLinked_List
    {
        private Node head;

    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
