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

        //Задание 2. Решить задачу о нахождении длины максимальной подпоследовательности с помощью матрицы.
        static void Print3(char[] lcs, int count)
        {
            Console.Write("Наибольшая общая подпоследовательность ");
            for (int i = 0; i < count; i++)
            {
                Console.Write($"{lcs[i]} ");
            }
            Console.WriteLine($"имеет {count} элементов");
        } //Печать результатов поиска ОНП
        static void LCS(string a, string b)
        {
            int ac = 0, bc = 0, countA = 0, countB = 0;
            char[] lcs1 = new char[a.Count()];
            char[] lcs2 = new char[b.Count()];
            for (int i = 0; i < a.Count(); i++) //сравнения строки а со строкой b
            {
                if(i + ac < b.Count())
                {
                    if (a[i] == b[i + ac])
                    {
                        lcs1[i] = a[i];
                        countA++;
                    }
                    else
                    {
                        for (int j = i + ac + 1; j < b.Count(); j++)
                        {
                            if (j + ac < b.Count())
                            {
                                if (a[i] == b[j + ac])
                                {
                                    lcs1[i] = a[i];
                                    ac++;
                                    countA++;
                                    break;
                                }
                            }
                            else break;
                        }
                    }
                } else break;
            }
            for (int n = 0; n < b.Count(); n++) //сравнения строки b со строкой a
            {
                if(n + bc < a.Count())
                {
                    if (b[n] == a[n + bc])
                    {
                        lcs2[n] = b[n];
                        countB++;
                    }
                    else
                    {
                        for (int m = n + bc + 1; m < a.Count(); m++)
                        {
                            if (m + bc < a.Count())
                            {
                                if (b[n] == a[m + bc])
                                {
                                    lcs2[n] = b[n];
                                    bc++;
                                    countB++;
                                    break;
                                }
                            }
                            else break;
                        }
                    }
                } else break;
            }
            if (countA > countB) Print3(lcs1, countA);
            else if (countA < countB) Print3(lcs2, countB);
            else
            {
                Console.WriteLine("Равны");
                Print3(lcs1, countA);
                Print3(lcs2, countB);
            }
        } //ОНП с помощью матрицы
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

            Console.WriteLine("Введите два массиа символов для нахождения общей наибольшей подпоследовательности:");
            string a = Console.ReadLine();
            string b = Console.ReadLine();
            LCS(a, b); //Задача 2 ОНП с помощью матрицы

            Console.ReadKey();
        }
    }
}
