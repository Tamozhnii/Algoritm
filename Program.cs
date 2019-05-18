using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritm                                      //Таможний Петр
{
    class Program
    {
        public static void Arr(out int[] a, int n, int max)
        {
            a = new int[n];
            Random random = new Random();
            for (int i = 0; i < a.Length; i++)
            {
                a[i] = random.Next(max);
            }
        }//Создание нового массива
        public static void CopyArr(out int[] b, int[] a)
        {
            b = new int[a.Length];
            for (int i = 0; i < b.Length; i++)
            {
                b[i] = a[i];
            }
        }//Копирование массива

        //Задание 1. Попробовать оптимизировать пузырьковую сортировку. Сравнить количество операций сравнения оптимизированной и неоптимизированной программы. Написать функции сортировки, которые возвращают количество операций.
        public static void BubbleSort(int[] b) //Пузырьковая сортировка
        {
            int complexity = (b.Length - 1) * (b.Length / 2);
            Console.WriteLine($"Coplexity Bubble sort is {complexity}");
            int arrCount = 0;
            int swapCount = 0;
            int x = 0;
            for (int j = 0; j < b.Length - 1; j++)
            {
                for (int i = 1; i < b.Length; i++)
                {
                    if (b[i] < b[i - 1])
                    {
                        x = b[i];
                        b[i] = b[i - 1];
                        b[i - 1] = x;
                        swapCount++;
                    }
                }
                arrCount++;
            }
            Console.Write($"After Bubble sort, arr: ");
            foreach (int i in b)
            {
                Console.Write("{0} ", i);
            }
            Console.WriteLine($"\nComplexity - {arrCount} and swaps - {swapCount}");
        }
        public static void MyBubbleSort(int[] a)
        {
            int arrCount = 0;
            int swapCount = 0;
            int x = 0;
            bool f;
            int n = a.Length;
            for (int i = 0; i < a.Length - 1; i++)
            {
                f = false;
                int d = 1;
                for (int j = 1; j < n; ++j)
                {
                    if (a[j] < a[j - 1])
                    {
                        x = a[j];
                        a[j] = a[j - 1];
                        a[j - d] = x;
                        f = true;
                        d = 1;
                        swapCount++;
                    }
                    else if (a[j] == a[j - 1]) d++;
                    else if (a[j] > a[j - 1]) d = 1;
                }
                n--;
                arrCount++;
                if (f == false)
                {
                    break;
                }
            }
            Console.Write($"After MyBubble sort, arr: ");
            foreach (int item in a)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine($"\nComplexity - {arrCount} and swaps - {swapCount}");
        } //Оптимизированная Пузырьковая сортировка

        //Задание 2. *Реализовать шейкерную сортировку.
        public static void ShakeSort(int[] a)
        {
            int complexity = (a.Length - 1) * (a.Length / 2);
            Console.WriteLine($"Coplexity Shaker sort is {complexity}");
            int arrCount = 0;
            int arrSwap = 0;
            int swap = 0;
            int t = a.Length;
            int o = 0;
            for (int i = 0; i < a.Length - 2; i++)
            {
                bool f = false;
                int d = 1;
                int b = 0;
                int n = a.Length - 1;
                for (int j = 1; j < t; j++)
                {
                    if (a[j] < a[j - 1])
                    {
                        swap = a[j];
                        a[j] = a[j - 1];
                        a[j - d] = swap;
                        arrSwap++;
                        d = 1;
                        f = true;
                    }
                    else if (a[j] == a[j - 1]) d++;
                    else if (a[j] > a[j - 1]) d = 1;
                }
                for (int k = n; k > o; k--)
                {
                    if (a[k] < a[k - 1])
                    {
                        swap = a[k];
                        a[k + b] = a[k - 1];
                        a[k - 1] = swap;
                        arrSwap++;
                        f = true;
                        b = 0;
                    }
                    else if (a[k] == a[k - 1]) b++;
                    else if (a[k] > a[k - 1]) b = 0;
                }
                t--;
                o++;
                arrCount++;
                if (f == false) break;
            }
            Console.Write("After Shake sort: ");
            foreach (int item in a)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine($"\nComplexity - {arrCount}, swaps - {arrSwap}");
        } //Шейкерная сортировка

        //Задание 3. Реализовать бинарный алгоритм поиска в виде функции, которой передаётся отсортированный массив. Функция возвращает индекс найденного элемента или –1, если элемент не найден.
        public static void BinarSearch(int[] a, int search, int index)
        {
            int[] b;
            int n = a.Length / 2;
            index += n;
            if (a.Length == 1 && a[0] == search)
            {
                Console.WriteLine($"Number {search} in array under the index: {index}");
            }
            else if (search == a[n]) Console.WriteLine($"Number {search} in array under the index: {index}");
            else if (a.Length % 2 != 0 && a.Length > 1)
            {
                if (search > a[n])
                {
                    b = new int[n];
                    for (int i = 0; i < n; i++)
                    {
                        b[i] = a[n + 1 + i];
                    }
                    index += 1;
                    BinarSearch(b, search, index);
                }
                else if (search < a[n])
                {
                    b = new int[n];
                    index -= n;
                    for (int i = 0; i < n; i++)
                    {
                        b[i] = a[i];
                    }
                    BinarSearch(b, search, index);
                }
            }
            else if (a.Length % 2 == 0 && a.Length > 1)
            {
                if (search > a[n])
                {
                    b = new int[n];
                    for (int i = 0; i < n; i++)
                    {
                        b[i] = a[n + i];
                    }
                    BinarSearch(b, search, index);
                }
                else if (search < a[n])
                {
                    b = new int[n];
                    index -= n;
                    for (int i = 0; i < n; i++)
                    {
                        b[i] = a[i];
                    }
                    BinarSearch(b, search, index);
                }
            }
            else Console.WriteLine($"Number {search} do not found in array");
        }//Бинарный поиск числа

        //Задание 4. *Подсчитать количество операций для каждой из сортировок и сравнить его с асимптотической сложностью алгоритма.
        public static void Stat(out int[] a, out int[] b, out int[] c, out int[] d,out int[] f, int length, int searchNum)
        {
            a = new int[length];
            b = new int[length];
            c = new int[length];
            d = new int[length];
            f = new int[length];
            Arr(out a, length, 10);
            Console.Write("\nArray: ");
            for (int i = 0; i < a.Length; i++)
            {
                Console.Write($"{a[i]} ");
            }
            Console.WriteLine();
            CopyArr(out c, a);
            CopyArr(out b, a);
            CopyArr(out d, a);
            BubbleSort(b);
            MyBubbleSort(c);
            ShakeSort(d);
            CopyArr(out f, d);
            BinarSearch(f, searchNum, 0);
        }//Выводит на экран статистику

        static void Main(string[] args)
        {
            int[] a, b, c, d, f;
            Stat(out a, out b, out c, out d, out f, 10, 7);
            Stat(out a, out b, out c, out d, out f, 100, 7); //Задание 1, 2, 3 Пузырьковая и Шейкерная сортировки + бинарный поиск

            Console.ReadKey();
        }
    }
}
