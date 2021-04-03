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

        protected Node recinsert(Node newnode, Node temp)
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

        public int Count_elements () {
            
            if (this.head == null){
                Console.WriteLine("it is nothing in the List");
                return 0;
            }
            Node temp = this.head;
            int count = 0;
            count = Reccount_elements(temp, count);
            return count;
        }

        public int Reccount_elements(Node temp, int count)
        {
            if (temp == null)
            {
                count++;
                return count;
            }
            else
            {
                count++;
                return Reccount_elements(temp.Next, count);

            }
        }

        public void Add_atPosition(int new_data, int position)
        {
            Node temp = this.head;
            
            Node new_Node = new Node(new_data);
            int count = 0;
            while (true)
            {
                if (count == position)
                {

                }
                if (temp.Next == null)
                {

                }

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
            Console.WriteLine(List_A.Count_elements());


        }
    }
}
