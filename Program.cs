using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritm                                      //Таможний Петр
{
    public class MyArray
    {
        Random random = new Random();
        int n = 10;
        int max = 10;
        int[] arr;
        public int N
        {
            set { n = value;  }
        }
        public int Max
        {
            set { max = value; }
        }
        public int[] Arr
        {
            get { return arr; }
            set
            {
                arr = new int[n];
                for (int i = 0; i < arr.Length; i++)
                {
                    arr[i] = random.Next(max);
                }
            }
        }
    }//Создание массива с указанной длиной и рандомным заполнением
    class Program
    {
        public static void Arr(out int[] a, int n, int max)
        {
            a = new int[n];
            MyArray myArray = new MyArray();
            myArray.N = n;
            myArray.Max = max;
            a = myArray.Arr;
        }
        //Задание 1. Попробовать оптимизировать пузырьковую сортировку. Сравнить количество операций сравнения оптимизированной и неоптимизированной программы. Написать функции сортировки, которые возвращают количество операций.
        public static void BubleSort(int[] a) //Пузырьковая сортировка
        {
            int[] b = new int[a.Length];
            b = a;
            int arrCount = 0;
            int swapCount = 0;
            int x = 0;
            for (int j = 0; j < b.Length - 1; j++)
            {
                for (int i = 1; i < b.Length; i++)
                {
                    if (b[i] < b[--i])
                    {
                        x = b[i];
                        b[i] = b[--i];
                        b[--i] = x;
                        swapCount++;
                    }
                }
                arrCount++;
            }
            Console.WriteLine($"After sort, arr: {b} \nUse array - {arrCount} and swap - {swapCount}");
        }

        public static void MyBubleSort(int[] b)
        {
            int[] a = new int[b.Length];
            int arrCount = 0;
            int swapCount = 0;
            int x = 0;
            int n = a.Length - 1;
            for (int i = 0; i < n; i++)
            {
                bool f = false;
                for (int j = 1; j < a.Length; j++)
                {
                    int d = 1;
                    if (a[j] < a[--j])
                    {
                        x = a[j];
                        a[j] = a[--j];
                        a[j - d] = x;
                        f = true;
                        d = 1;
                        swapCount++;
                    } else if(a[j] == a[--j])
                    {
                        d++;
                    }
                }
                arrCount++;
                if (f == false)
                {
                    break;
                }
                n--;
            }
            Console.WriteLine($"After sort, arr: {b} \nUse array - {arrCount} and swap - {swapCount}");
        } //Оптимизированная Пузырьковая сортировка

        static void Main(string[] args)
        {
            int[] a;
            Arr(out a, 10, 10);
            for (int i = 0; i < a.Length; i++)
            {
                Console.Write($"{a[i]} ");
            }

            Console.ReadKey();
        }
    }
}
