using System;

namespace ASD_02
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите N");
            int N = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите M");
            int M = Convert.ToInt32(Console.ReadLine());
            int[,] array = new int[M, N];
            for (int i = 0; i < M; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    Random rnd = new Random();
                    array[i, j] = rnd.Next(1, 50);
                    if (j == N - 1)
                    {
                        Console.WriteLine(array[i, j]);
                    } else
                    {
                        Console.Write(array[i, j] + " ");
                    }
                }
            }


            int iInd = array.GetLength(0) / 2;
            int jInd = array.GetLength(0) / 2;

            int iStep = 1;
            int jStep = 1;
            int maxNum = array[iInd, jInd];
            int maxI = iInd;
            int maxJ = jInd;
            Console.Write(array[iInd, jInd] + " ");
            for (int i = 0; i < M; i++)
            {
                for (int h = 0; h < i; h++)
                {
                    Console.Write(array[iInd, jInd += jStep] + " ");
                    if (array[iInd, jInd] > maxNum)
                    {
                        maxNum = array[iInd, jInd];
                        maxI = iInd;
                        maxJ = jInd;
                    }
                }
                for (int v = 0; v < i; v++)
                {
                    Console.Write(array[iInd += iStep, jInd] + " ");
                    if (array[iInd, jInd] > maxNum)
                    {
                        maxNum = array[iInd, jInd];
                        maxI = iInd;
                        maxJ = jInd;
                    }
                }
                jStep = -jStep;
                iStep = -iStep;
            }
            for (int h = 0; h < array.GetLength(0) - 1; h++)
            {
                Console.Write(array[iInd, jInd += jStep] + " ");
                if (array[iInd, jInd] > maxNum)
                {
                    maxNum = array[iInd, jInd];
                    maxI = iInd;
                    maxJ = jInd;
                }
            }
            Console.WriteLine($"");
            Console.WriteLine($"The largest num is {maxNum} [{maxI} {maxJ}]");
            if(maxI == maxJ)
            {
                Console.WriteLine("На головній");
            } else if(maxJ > maxI)
            {
                Console.WriteLine("Зверху");
            } else
            {
                Console.WriteLine("Знизу");
            }
        }
    }
}
