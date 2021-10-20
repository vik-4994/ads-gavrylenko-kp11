using System;

namespace ASD_01
{
    class Program
    {
        static void Main(string[] args)
        {
            // Завдання №1 7
            double x = Convert.ToDouble(Console.ReadLine());
            double y = Convert.ToDouble(Console.ReadLine());
            double z = Convert.ToDouble(Console.ReadLine());
            double a, b;
            if (Math.Sin(x) >= Math.Cos(y))
            {
                a = Math.Pow(Math.Sin(x) - Math.Cos(y), 1.0 / 3);
            }
            else
            {
                a = Math.Pow(Math.Cos(y) - Math.Sin(x), 1.0 / 3);
            }
            b = Math.Cos(Math.Sin(a * a));
            Console.WriteLine($"a = {a}, b = {b}");

            // Завдання №2 8
            int n = Convert.ToInt16(Console.ReadLine());
            double num;
            for (int i = 0; i < n; i++)
            {
                for (int j = 2; j < n; j++)
                {
                    if (i % j == 0 && j != i)
                    {
                        break;
                    }
                    if (j == i - 1 || j == i)
                    {
                        num = Math.Pow(2, i) - 1;
                        if (num < n)
                        {
                            Console.WriteLine(num);
                        }
                        break;
                    }
                }
            }
        }
    }
}
