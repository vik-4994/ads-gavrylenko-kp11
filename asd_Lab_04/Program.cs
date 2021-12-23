using System;

namespace ASD_04
{
    class Program
    {
        static void Main(string[] args)
        {
            SLNode n = new SLNode(1,2,5);
            bool bol = true;
            while (bol)
            {
                Console.WriteLine("Введіть цифру - (1) AddFirst; (2) AddLast; (3) AddAtPosition; (4) DeleteFirst; (5) DeleteLast; (6) DeleteAtPosition; (7) Print; (8) FindMaxAndAdd; (9) закінчити виконання програми");
                int num = Convert.ToInt32(Console.ReadLine());
                int dat;
                int pos;
                switch (num)
                {
                    case 1:
                        Console.WriteLine("Введіть данні");
                        dat = Convert.ToInt32(Console.ReadLine());
                        n.AddFirst(dat);
                        break;
                    case 2:
                        Console.WriteLine("Введіть данні");
                        dat = Convert.ToInt32(Console.ReadLine());
                        n.AddLast(dat);
                        break;
                    case 3:
                        Console.WriteLine("Введіть позицію");
                        pos = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Введіть данні");
                        dat = Convert.ToInt32(Console.ReadLine());
                        n.AddAtPosition(dat, pos);
                        break;
                    case 4:
                        n.DeleteFirst();
                        break;
                    case 5:
                        n.DeleteLast();
                        break;
                    case 6:
                        Console.WriteLine("Введіть позицію");
                        pos = Convert.ToInt32(Console.ReadLine());
                        n.DeleteAtPosition(pos);
                        break;
                    case 7:
                        n.Print();
                        break;
                    case 8:
                        Console.WriteLine("Введіть данні");
                        dat = Convert.ToInt32(Console.ReadLine());
                        n.FindMaxElemAndAdd(dat);
                        break;
                    case 9:
                        bol = false;
                        break;
                }
            }
        }

        class SLNode
        {
            private Node tail;

            public SLNode(params int[] arr)
            {

                if(arr.Length != 0)
                {
                    tail = new Node(arr[arr.Length - 1]);
                    Node h = tail;
                    for (int i = 0; i < arr.Length - 1; i++)
                    {

                        h.next = new Node(tail, arr[i]);
                        h = h.next;
                    }
                }
            }

            public void AddFirst(int data)
            {
                if(tail == null)
                {
                    tail = new Node(data);
                }
                else
                {
                    tail.next = new Node(tail.next, data);
                }
            }

            public void AddLast(int data)
            {
                if (tail == null)
                {
                    tail = new Node(data);
                }
                else
                {
                    tail.next = new Node(tail.next, data);
                    tail = tail.next;
                }
            }

            public void AddAtPosition(int data, int position)
            {
                if(tail == null)
                {
                    tail = new Node(data);
                } else
                {
                    Node m = tail;
                    for (int i = 1; i < position; i++)
                    {
                        m = m.next;
                    
                    }
                    m.next = new Node(m.next, data);
                }
            }

            public void DeleteFirst()
            {
                if(tail != null)
                {
                    if(tail.next == tail)
                    {
                        tail = null;
                    }
                    else
                    {
                        tail.next = tail.next.next;
                    }
                }
            }

            public void DeleteLast()
            {
                if(tail != null)
                {
                    if (tail.next == tail)
                    {
                        tail = null;
                    }
                    else 
                    {
                        Node m = tail.next;
                        while(m.next != tail) 
                        {
                            m = m.next; 
                        }
                        m.next = m.next.next;
                        tail = m;
                    }
                }
            }

            public void DeleteAtPosition(int position)
            {
                if(tail != null)
                {
                    if (tail.next == tail)
                    {
                        tail = null;
                    }
                    else
                    {
                        Node m = tail;
                        for (int i = 1; i < position; i++)
                        {
                            m = m.next;
                        }
                        if(m.next == tail)
                        {
                            tail = m;
                        }
                        m.next = m.next.next;
                    }
                }
            }

            public void Print()
            {
                if(tail == null)
                {
                    Console.Write("Елементов нет");
                } else
                {
                    Node m = tail.next;
                    do
                    {
                        Console.Write($"{m.data} ");
                        m = m.next;
                    }
                    while (m != tail.next);
                    Console.WriteLine();
                }
            }

            public void FindMaxElemAndAdd(int data)
            {
                if(tail == null)
                {
                    tail = new Node(data);
                } else
                {
                    Node max = tail;
                    Node mn = tail;
                    while(mn.next != tail)
                    {
                        if(mn.data > max.data)
                        {
                            max = mn;
                        }
                        mn = mn.next;
                    }
                    max.next = new Node(max.next, data);
                }
            }
            class Node
            {
                public Node next;
                public int data;
                public Node(Node next, int data)
                {
                    this.next = next;
                    this.data = data;
                }
                public Node(int data)
                {
                    this.data = data;
                    this.next = this;
                }
            }
        }
    }
}
