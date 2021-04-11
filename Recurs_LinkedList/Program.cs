using System;

namespace Recurs_LinkedList
{

    class Node {
        private int data;
        private Node next;

        public int Data { get { return data; } set { data = value; } }
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

        public int First{ get 
            {
                return this.head.Data;
            }
            set
            {
                this.head.Data = value;
            }
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
            if (position <= 0)
            {
                Console.WriteLine("elements in List starts with 1st and bigger");
                return;
            }
            else
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
                if (position == count)
                {
                    for (int i = 1; i < count - 1; i++)
                    {
                        temp = temp.Next;
                    }
                    Node my = temp.Next;
                    temp.Next = new_Node;
                    new_Node.Next = my;
                    return;
                }
                if (position == 1)
                {
                    Node my = this.head;
                    this.head = new_Node;
                    new_Node.Next = my;
                    return;
                }
                while (true)
                {
                    if (number == position - 1)
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

        public void Print_Reverse()
        {
            Node temp = this.head;
            int count = Count_elements();
            int[] arr=new int [count];
            for (int i=0; i<count; i++)
            {
                arr[i] = temp.Data;
                temp = temp.Next;
            }
            Console.WriteLine("elements in the List in reverse order: ");
            
            for (int i= arr.Length-1; i>=0; i--)
            {
                Console.Write(arr[i]+", ");
            }
        }

        public void Print()
        {
            Node temp = this.head;
            Console.WriteLine("elements in List in right order: ");
            while (temp != null)
            {
                Console.Write(temp.Data + ", ");
                temp = temp.Next;
            }
            Console.WriteLine();
            return;
        }
        public static RLinked_List operator +(RLinked_List r1, RLinked_List r2)
        {
            Node temp2 = r2.head;
            Node temp1 = r1.head;
            RLinked_List r3 = new RLinked_List();
            while (temp1 != null)
            {
                r3.insertend(temp1.Data);
                temp1 = temp1.Next;
            }

            while (temp2 != null)
            {
                r3.insertend(temp2.Data);
                temp2 = temp2.Next;
            }
            return r3;
        }

        public static bool operator >(RLinked_List r1, RLinked_List r2)
        {
            Node temp1 = r1.head;
            Node temp2 = r2.head;
            int count1 = 0;
            int count2 = 0;
            while (temp1 != null)
            {
                count1++;
                temp1 = temp1.Next;
            }
            while (temp2 != null)
            {
                count2++;
                temp2 = temp2.Next;
            }
            if(count1 == count2)
            {
                return false;
            }
            if (count1 > count2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool operator <(RLinked_List r1, RLinked_List r2)
        {
            Node temp1 = r1.head;
            Node temp2 = r2.head;
            int count1 = 0;
            int count2 = 0;
            while (temp1 != null)
            {
                count1++;
                temp1 = temp1.Next;
            }
            while (temp2 != null)
            {
                count2++;
                temp2 = temp2.Next;
            }
            if (count1 == count2)
            {
                return false;
            }
            if (count1 < count2)
            {
                return true;
            }
            else
            {
                return false;
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
            List_A.insertend(19);
            List_A.insertend(87);
            Console.WriteLine("elements in A");
            List_A.Print();
            List_A.Add_atPosition(34, -1);

          /*  RLinked_List List_B = new RLinked_List(78);
            List_B.insertend(3);
            List_B.insertend(5);
            List_B.insertend(90);
            List_B.insertend(45);
            Console.WriteLine("elements in B");
            List_B.Print();
            Console.WriteLine();

            RLinked_List List_Sum = new RLinked_List();

            List_Sum = List_A + List_B;
            Console.WriteLine("elements in Sum");
            List_Sum.Print();
            RLinked_List copy_Sum = new RLinked_List(List_Sum);
            Console.WriteLine("elements in copy");
            copy_Sum.Print();
            Console.WriteLine();

            bool b = List_A > List_B;
            bool c = List_A < List_B;
            bool s = List_A < List_Sum;

            Console.WriteLine("number of elements in list A: "+ List_A.Count_elements());
            Console.WriteLine("number of elements in list B: " + List_B.Count_elements());
            Console.WriteLine();

            Console.WriteLine(" operation List_A bigger List_B: " + b );
            Console.WriteLine("operation List_A less List_B: " + c);
            Console.WriteLine("operation List_A less List_Sum: " + s);
            Console.WriteLine();

            List_A.Add_atPosition(65, 4);
            Console.WriteLine("add 65 at position 4 List A");
            List_A.Print();
            Console.WriteLine();

            List_A.insertend(1);
            Console.WriteLine("add 1 at last position");
            List_A.Print();
            Console.WriteLine();

            List_A.Delete_Last();
            Console.WriteLine("delete last position");
            List_A.Print();
            Console.WriteLine();

            List_A.Delete_withValue(56);
              List_A.Delete_withValue(7);
            Console.WriteLine("trying to delete 56 and 7");
            List_A.Print();
            Console.WriteLine();

            List_A.First = 44;
            Console.WriteLine("change value first in A");
            List_A.Print();
            Console.WriteLine();

            Console.WriteLine(List_A.First);
              List_A.Print_Reverse();
            Console.WriteLine();

            List_A.insertend(99);
            Console.WriteLine("elements in A");
            List_A.Print();
            Console.WriteLine("elements in B");
            List_B.Print();
            Console.WriteLine();

            bool d = List_A > List_B;
            bool e = List_A < List_B;
            Console.WriteLine(" operation List_A bigger List_B: " + d);
            Console.WriteLine("operation List_A less List_B: " + e);
            Console.WriteLine();*/
        }
    }
}
