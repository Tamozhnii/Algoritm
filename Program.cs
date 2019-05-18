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
            Console.WriteLine($"\nUse array - {arrCount} and swaps - {swapCount}");
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
            Console.WriteLine($"\nUse array - {arrCount} and swaps - {swapCount}");
        } //Оптимизированная Пузырьковая сортировка
        public static void TotalBubble(out int[] a,out int[] b,out int[] c, out int[] d, int length)
        {
            a = new int[length];
            b = new int[length];
            c = new int[length];
            d = new int[length];
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
        }//Выводит на экран итоги Пузырьковой сортировки

        //Задание 2. *Реализовать шейкерную сортировку.
        public static void ShakeSort(int[] a)
        {
            int arrCount = 0;
            int arrSwap = 0;
            int swap = 0;
            for (int i = 0; i < a.Length - 2; i++)
            {
                int n = a.Length - 1;
                for (int j = 1; j < a.Length; j++)
                {
                    if (a[j] < a[j - 1])
                    {
                        swap = a[j];
                        a[j] = a[j - 1];
                        a[j - 1] = swap;
                        arrSwap++;
                    }
                }
                for (int k = n; k > 0; k--)
                {
                    if (a[k] < a[k - 1])
                    {
                        swap = a[k];
                        a[k] = a[k - 1];
                        a[k - 1] = swap;
                        arrSwap++;
                    }
                }
                arrCount++;
            }
            Console.Write("After Shake sort: ");
            foreach (int item in a)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine($"\nArr use - {arrCount}, swaps - {arrSwap}");
        } //Шейкерная сортировка

        static void Main(string[] args)
        {
            int[] a, b, c, d;
            TotalBubble(out a, out b, out c, out d, 10);
            TotalBubble(out a, out b, out c, out d, 100);
            TotalBubble(out a, out b, out c, out d, 200); //Задание 1, 2 Пузырьковая и Шейкерная сортировки


            Console.ReadKey();
        }
    }
}
