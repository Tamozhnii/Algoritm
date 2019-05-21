using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritm
{
    class Program
    {
        //Задание 1 *Количество маршрутов с препятствиями. Реализовать чтение массива с препятствием и нахождение количество маршрутов.
        static void PrintM(int x, int y, int[,] M) //Печать ходов по доске
        {
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    Console.Write($"{M[i, j]}".PadRight(6));
                }
                Console.WriteLine();
            }
        }
        static void Move(int let, int x, int y, int[,] M) //Ход короля по доске
        {
            for (int a = 0; a < x; a++)
            {
                for (int b = 0; b < y; b++)
                {
                    M[a, b] = 1;
                }
            }
            Let(let, x, y, M);
            for (int j = 0; j < y; j++)
            {
                if (M[0, j] != 0) M[0, j] = 1;
                else
                {
                    for (int k = j; k < y; k++)
                    {
                        M[0, k] = 0;
                    }
                }
            }
            for (int i = 1; i < x; i++)
            {
                if (M[i, 0] != 0) M[i, 0] = 1;
                else
                {
                    for (int p = i; p < x; p++)
                    {
                        M[p, 0] = 0;
                    }
                }
                for (int j = 1; j < y; j++)
                {
                    if (M[i, j] != 0) M[i, j] = M[i - 1, j] + M[i, j - 1];
                }
            }
            PrintM(x, y, M);
        }
        static void Let(int let, int x, int y, int[,] M) //Расстановка препятствий
        {
            int n, m;
            Random random = new Random();
            for (int i = 0; i < let; i++)
            {
                n = random.Next(x);
                m = random.Next(y);
                M[n, m] = 0;
            }
        }
        static void Main(string[] args)
        {
            int x, y, let;
            Console.WriteLine("Укажите размерность массива");
            Console.Write("Строк: ");
            int.TryParse(Console.ReadLine(), out x);
            Console.Write("Столбцов: ");
            int.TryParse(Console.ReadLine(), out y);
            Console.Write("Количество препятствий на доске: ");
            int.TryParse(Console.ReadLine(), out let);
            int[,] M = new int[x, y];
            Move(let, x, y, M); //Задание 1 Пути на доске с препятствиями

            Console.ReadKey();
        }
    }
}
