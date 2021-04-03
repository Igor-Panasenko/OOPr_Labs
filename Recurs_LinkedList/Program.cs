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
            recinsert(newnode,temp);
            return;
        }

        protected Node recinsert(Node newnode, Node temp)
        {
            if (temp.Next == null)
            {
                temp.Next = newnode;
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
            if (temp.Next == null)
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
            
            int count = Count_elements();
            if (count < position)
            {
                Console.WriteLine("this position is too far, your element will be added to the end");
                insertend(new_data);
                return;
            }
            Node temp = this.head;
            Node new_Node = new Node(new_data);
            int number = 1;
            if(position == count)
            {
                for(int i=1; i<count-1; i++)
                {
                    temp = temp.Next;
                }
                Node my = temp.Next;
                temp.Next = new_Node;
                new_Node.Next = my;
                return;
            }
            if(position == 1)
            {
                Node my = this.head;
                this.head = new_Node;
                new_Node.Next = my;
                return;
            }
            while (true)
            {
                if (number == position-1)
                {
                    Node following = temp.Next;
                    temp.Next = new_Node;
                    new_Node.Next = following;
                    return;
                }
                else
                {
                    number++;
                    temp = temp.Next;
                }
            }
        }
        
        public int Delete_Last()
        {
            Node temp = this.head;
            int number=recDelete_Last(temp);
            return number;
        }
        public int recDelete_Last(Node temp)
        {
            if (temp.Next.Next == null)
            {
                int count = temp.Next.Data;
                temp.Next = null;
                return count;
            }
            else
            {
                return recDelete_Last(temp.Next);
            }

        }

        public int? Delete_withValue (int value)
        {
            Node temp = this.head;
            if (temp.Data == value)
            {
                int count = temp.Data;
                Node my = temp.Next;
                this.head = my;
                return count;
            }
            temp = temp.Next;
            while (true)
            {
                if (temp.Next.Data == value && temp.Next.Next!=null)
                {
                    int number = temp.Data;
                    temp.Next = temp.Next.Next;
                    return number;
                }
                else
                {
                    if(temp.Next.Data == value && temp.Next.Next == null)
                    {
                        int number = temp.Next.Data;
                        temp.Next = null;
                        return number;
                    }
                }
                temp = temp.Next;
                if (temp.Next == null)
                {
                    break;
                }
            }
            Console.WriteLine("in List no elements with this value");
            return null;
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
            List_A.insertend(19);
            Console.WriteLine(List_A.Count_elements());
            List_A.Add_atPosition(65, 3);
            List_A.insertend(1);
            List_A.Delete_Last();
            List_A.Delete_withValue(5);
            List_A.insertend(1);


        }
    }
}
