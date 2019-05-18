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
        public static void TotalBubble(out int[] a,out int[] b,out int[] c, int length)
        {
            a = new int[length];
            b = new int[length];
            c = new int[length];
            Arr(out a, length, 10);
            Console.Write("\nArray: ");
            for (int i = 0; i < a.Length; i++)
            {
                Console.Write($"{a[i]} ");
            }
            Console.WriteLine();
            CopyArr(out c, a);
            CopyArr(out b, a);
            BubbleSort(b);
            MyBubbleSort(c);
        }
        static void Main(string[] args)
        {
            int[] a, b, c;
            TotalBubble(out a, out b, out c, 10);
            TotalBubble(out a, out b, out c, 100);
            TotalBubble(out a, out b, out c, 500);

            Console.ReadKey();
        }
    }
}
