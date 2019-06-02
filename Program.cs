using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritm
{
    class Program                                      //Таможний П.И.
    {
        static string BiNumber(int i, ref string j)
        {
            if (i > 0)
            {
                BiNumber(i / 2, ref j);
                j += (i % 2).ToString();
            }
            if (i == 0)
            {
                return j;
            }
            return j;
        } //Бинарное число

        static int MyPow(int a, int count) 
        {
            int b = a;
            if (a != 0)
            {
                if (count == 0)
                {
                    return 1;
                }
                else
                {
                    for (int i = 1; i < count; i++)
                    {
                        b *= a;
                    }
                    return b;
                }
            }
            else return 0;
        }//Степень без рекурсии

        static int RecPow(int a, int count)
        {
            if (a != 0)
            {
                if(count != 0)
                {
                    if(count > 0)
                    {
                        count--;
                        a *= RecPow(a, count);
                        return a;
                    }
                } return 1;
            } return 0;
        } //Степень рекурсией

        static int NewPow(int a, int count)
        {
            if (a != 0)
            {
                if (count != 0)
                {
                    if (count > 1)
                    {
                        if(count % 2 != 0)
                        {
                            count--;
                            int n = a * NewPow(a, count);
                            return n;
                        }
                        else 
                        {
                            count--;
                            a *= NewPow(a, count);
                        }
                    } return a;
                }
                return 1;
            }
            return 0;
        } //Степень рекурсией со свойствами четности

        static int CountRoad(int a, int b)
        {
            int count = 0;
            List<int> list = new List<int>() { a };
            for (int i = 0; i < list.Count; i++)
            {
                if(list[i] < b)
                {
                    list.Add(list[i] + 1);
                    list.Add(list[i] * 2);
                }
                else if (list[i] == b)
                {
                    count++;
                }
            }
            return count;
        } //Количество ходов калькулятора с помощью массива

        static void CountRoadRec(int a, int b, ref int count)
        {
            if(a < b)
            {
                int a1 = a + 1;
                int a2 = a * 2;
                CountRoadRec(a1, b, ref count);
                CountRoadRec(a2, b, ref count);
            }
            else if (a == b) count++;
        } //Количество ходов калькулятора с помощью рекурсии

        static void Main(string[] args)
        {
            string biNumber = null;
            Console.Write("Введите число, для получекния его двоичного представления: ");
            int x = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(BiNumber(x, ref biNumber));//Задание 1

            Console.WriteLine("Три вида возведения в степень:");
            Console.Write("Введите число: ");
            int a = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите степень: ");
            int b = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Циклом: {MyPow(a, b)}");//Задание 2
            Console.WriteLine($"Рекурсией: {RecPow(a, b)}");
            Console.WriteLine($"Рекурсией со свойствами четности степени: {NewPow(a, b)}");

            Console.WriteLine("Количество ходов для Калькулятора от 3 до 20");
            Console.WriteLine($"Циклом: {CountRoad(3, 20)}");//Задание 3
            int count = 0;
            CountRoadRec(3, 20, ref count);
            Console.WriteLine($"Рекурсией: {count}");

            Console.ReadKey();
        }
    }
}
