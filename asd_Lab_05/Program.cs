using System;
using System.Collections.Generic;

namespace LAB_05_ADS
{
    class Program
    {
        static void Main(string[] args)
        {
            bool u = true;
            while (u)
            {
                Console.WriteLine($"(1) - Рандомно генерований масив; (2) - Приклад; (3) - Закінчти виконання програми");
                string str = Console.ReadLine();
                switch (str)
                {
                    case "1":
                        Console.WriteLine("Введіть N");
                        int N = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Введіть M");
                        int M = Convert.ToInt32(Console.ReadLine());
                        sort(N, M);
                        break;
                    case "2":
                        Console.WriteLine("Приклад: N = 8, M = 3");
                        sort(8, 3);
                        break;
                    case "3":
                        u = false;
                        break;
                }
            }
        }

        static void sort(int N, int M)
        {
            int[] arr = new int[N];
            int even = 0;
            int odd = 0;
            Random rnd = new Random();
            for (int i = 0; i < N; i++)
            {
                while (true)
                {
                    int a = rnd.Next(-50, 50);
                    if(even < N / 2.0 && Array.IndexOf(arr, a) == -1 && a % 2 == 0)
                    {
                        arr[i] = a;
                        even++;
                        break;
                    } else if(odd < N / 2.0 && Array.IndexOf(arr, a) == -1 && a % 2 == 1)
                    {
                        arr[i] = a;
                        odd++;
                        break;
                    }
                }
            }

            List<int> evenArr = new List<int>();
            List<int> oddArr = new List<int>();
            for (int i = 0; i < N; i++)
            {
                if(arr[i] % 2 == 0)
                {
                    evenArr.Add(arr[i]);
                } else
                {
                    oddArr.Add(arr[i]);
                }
            }
            List<int[]> evenSortArr = Sort(evenArr.ToArray(), 0, evenArr.Count, M);
            List<int[]> oddSortArr = Sort(oddArr.ToArray(), 0, evenArr.Count, M);
            
            evenArr = UnionUp(evenSortArr);
            oddArr = UnionDown(oddSortArr);
            PrintArr(evenArr.ToArray(), ConsoleColor.DarkRed);
            PrintArr(oddArr.ToArray(), ConsoleColor.Green);
            Console.WriteLine();
        }

        static List<int[]> Sort(int[] arr, int min, int max, int M)
        {
            List<int[]> array = new List<int[]>();
            if(max - min < M)
            {
                int[] arr1 = new int[max - min];
                Array.Copy(arr, min, arr1, 0, max - min);
                if (arr[0] % 2 == 0)
                {
                    arr1 = ParseUp(arr1, 0, max - min);
                } else
                {
                    arr1 = ParseDown(arr1, 0, max - min);
                }
                array.Add(arr1);
            } else
            {
                array.AddRange(Sort(arr, 0, Convert.ToInt32(Math.Floor(max / 2.0)), M));
                array.AddRange(Sort(arr, Convert.ToInt32(Math.Round(max / 2.0)), max, M));
            }
            return array;
        }

        static void PrintArr(int[] arr, ConsoleColor col)
        {
            Console.ForegroundColor = col;
            foreach (int n in arr)
                Console.Write(n + "\t");

            Console.ForegroundColor = ConsoleColor.White;
        }

        static int[] ParseDown(int[] array, int low, int high)
        {
            int key = 0;
            for (int i = low; i < high; i++)
            {
                key = array[i];
                int j = i - 1;
                while (j >= 0 && array[j] < key)
                {
                    array[j + 1] = array[j];
                    j -= 1;
                }
                array[j + 1] = key;
            }
            return array;
        }

        static int[] ParseUp(int[] array, int low, int high)
        {
            int key = 0;
            for (int i = low; i < high; i++)
            {
                key = array[i];
                int j = i - 1;
                while (j >= 0 && array[j] > key)
                {
                    array[j + 1] = array[j];
                    j -= 1;
                }
                array[j + 1] = key;
            }
            return array;
        }

        static List<int> UnionUp(List<int[]> l)
        {
            List<int> array = new List<int>();
            array.AddRange(l[0]);
            Console.WriteLine(array.Count);

            for (int i = 1; i < l.Count; i++)
            {
                for(int j = 0; j < l[i].Length; j++)
                {
                    for (int k = 0; k < array.Count; k++)
                    {
                        if (l[i][j] < array[k])
                        {
                            array.Insert(k, l[i][j]);
                            break;
                        }
                        else if (k == array.Count - 1)
                        {
                            array.Add(l[i][j]);
                            break;
                        }
                    }
                }
            }
            return array;
        }

        static List<int> UnionDown(List<int[]> l)
        {
            List<int> array = new List<int>();
            array.AddRange(l[0]);

            for (int i = 1; i < l.Count; i++)
            {
                for (int j = 0; j < l[i].Length; j++)
                {
                    for (int k = 0; k < array.Count; k++)
                    {
                        if (l[i][j] > array[k])
                        {
                            array.Insert(k, l[i][j]);
                            break;
                        }
                        else if (k == array.Count - 1)
                        {
                            array.Add(l[i][j]);
                            break;
                        }
                    }
                }
            }

            return array;
        }
    }
}
