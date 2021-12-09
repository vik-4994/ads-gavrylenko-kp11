using System;

namespace ASD_03
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            int[] array = new int[10];
            int[]firstArray = new int[10];
            Console.WriteLine("Початок");
            for(int i = 0; i < array.Length; i++)
            {
                array[i] = rnd.Next(0, 20000);
                firstArray[i] = array[i];
                if(i == array.Length - 1)
                {
                    Console.WriteLine(array[i]);
                } else
                {
                    Console.Write($"{array[i]} ");
                }
            }
            bool flag = true;
            int buffer;
            string str = "";
            while (flag)
            {
                flag = false;
                for(int i = 0; i < array.Length - 1; i++)
                {
                    if((str + array[i]).Length < (str + array[i + 1]).Length)
                    {
                        buffer = array[i];
                        array[i] = array[i + 1];
                        array[i + 1] = buffer;
                        flag = true;
                    }
                }
            }

            Console.WriteLine("Проміжний масив");
            for(int t = 0; t < array.Length; t++)
            {
                if (t == array.Length - 1)
                {
                    Console.WriteLine(array[t]);
                }
                else
                {
                    Console.Write($"{array[t]} ");
                }
            }

            flag = true;

            while (flag)
            {
                flag = false;
                for (int i = 0; i < array.Length - 1; i++)
                {
                    if (Convert.ToString(array[i]).Length == Convert.ToString(array[i + 1]).Length && array[i] > array[i + 1])
                    {
                        buffer = array[i];
                        array[i] = array[i + 1];
                        array[i + 1] = buffer;
                        flag = true;
                    }
                }
            }

            Console.WriteLine("Кінець");
            for (int i = 0; i < array.Length; i++)
            {
                if (i == array.Length - 1)
                {
                    if (firstArray[i] == array[i])
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine($"{array[i]} ");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine($"{array[i]} ");
                    }
                }
                else
                {
                    if(firstArray[i] == array[i])
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write($"{array[i]} ");
                    } else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write($"{array[i]} ");
                    }
                }
            }
        }
    }
}
