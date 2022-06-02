using System;

namespace LAB_06_ADS
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue queue = new Queue();
            bool bol = true;
            while (bol)
            {
                Console.WriteLine("Щоб створити чергу - натисніть (0), щоб додати елемент - натисніть (1), щоб знищити чергу - натисніть (2), щоб вивести чергу - натисніть (3), щоб видалити елемент з черги - натисніть (4), щоб показати головуючий елемент - настисніть (5)");
                string command = Console.ReadLine();
                switch (command)
                {
                    case "0":
                        Console.Write("Впишіть розмір: ");
                        int size = Convert.ToInt32(Console.ReadLine());
                        queue.InitQueue(size);
                        break;
                    case "1":
                        Console.Write("Впишіть число: ");
                        int num = Convert.ToInt32(Console.ReadLine());
                        if(num >= 0)
                        {
                            bol = queue.Enqueue(num);
                            queue.Print();
                        } else
                        {
                            Console.WriteLine("Неправильний ввід даних");
                        }
                        break;
                    case "2":
                        queue.DestroyQueue();
                        bol = false;
                        break;
                    case "3":
                        queue.Print();
                        break;
                    case "4":
                        bol = queue.Dequeue();
                        queue.Print();
                        break;
                    case "5":
                        queue.Head();
                        break;
                }
            }
            Console.WriteLine("Програма завершена.");
        }
        class Queue {
            public int head = -1;
            public int tail = -1;
            public int size = 0;
            public int count = 0;
            public int[] arr;

            public Queue()
            {

            }

            public void InitQueue(int size)
            {
                this.size = size;
                arr = new int[size];
                head = 0;
            }

            public void DestroyQueue()
            {
                arr = new int[0];
                head = -1;
                tail = -1;
                size = 0;
                count = 0;
                Console.WriteLine("Черга знищена");
            }

            public bool Enqueue(int num)
            {
                bool tmpbool = true;
                if (count == size)
                {
                    Console.WriteLine("Черга повністю заповнена");
                    Console.WriteLine("Збільшити чергу? (1) - Так;");
                    string a = Console.ReadLine();
                    switch (a)
                    {
                        case "1":
                            AddSize();
                            break;
                    }
                } else 
                {
                    tail++;
                    if (tail == size)
                    {
                        tail = 0;
                    }
                    arr[tail] = num;
                    count++;
                }
                if(num == 0)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        tmpbool = Dequeue();
                    }
                    if (count == 0)
                    {
                        tmpbool = false;
                        Console.WriteLine("Черга порожня");
                    }
                }
                return tmpbool;
            }

            public bool Dequeue()
            {
                if (count == 0)
                {
                    Console.WriteLine("Черга не заповнена");
                    return false;
                } else
                {
                    count--;
                    head++;
                    if(head == size)
                    {
                        head = 0;
                    }
                    if(count == 0)
                    {
                        head = 0;
                        tail = -1;
                    }
                    return true;
                }
            }

            public void Head()
            {
                Console.WriteLine($"{arr[head]}");
            }

            public void Print()
            {
                if (!(count == 0))
                {
                    if(tail < head)
                    {
                        for(int i = head; i < size; i++)
                        {
                            Console.Write(arr[i]);
                            Console.Write(",");
                        }
                        for(int i = 0; i <= tail; i++)
                        {
                            Console.Write(arr[i]);
                            Console.Write(",");
                        }
                    } else
                    {
                        for(int i = head; i <= tail; i++)
                        {
                            Console.Write(arr[i]);
                            Console.Write(",");
                        }
                    }
                    Console.WriteLine();
                } else
                {
                    Console.WriteLine("Черга порожня");
                }
            }

            public void AddSize()
            {
                Console.WriteLine("Введіть число на котре збільшиться розмір черги");
                int a = Convert.ToInt32(Console.ReadLine());
                size += a;
                int[] tmparr = new int[size];
                if (head > tail){
                    for(int i = 0; i <= tail; i++)
                    {
                        tmparr[i] = arr[i];
                    }
                    int tmp = head;
                    for (int i = head + a; i < size; i++)
                    {
                        tmparr[i] = arr[tmp];
                        tmp = tmp + 1;
                    }
                    head += a;
                } else
                {
                    for (int i = head; i <= tail; i++)
                    {
                        tmparr[i] = arr[i];
                    }
                }
                arr = tmparr;
            }
        }
    }
}
