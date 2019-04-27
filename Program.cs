using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritm
{                               // Таможний П.И.
    class Program
    {
        static public void Automorf(int n) //Определение автоморфных чисел от 1 до n
        {
            for (int i = 1; i <= n; i++)
            {
                string w = "1";
                int pow = Convert.ToInt32(Math.Pow(i, 2));
                int j = i;
                int count = 0;
                while (j > 0)
                {
                    j /= 10;
                    count++;
                }
                while (count > 0)
                {
                    w += "0";
                    count--;
                }
                int m = pow % int.Parse(w);
                if (m == i)
                {
                    Console.Write($"{i} ");
                }
            }
        }

        static public int MyRandom(int n) //Собственный метод генерации случайных чисел от 0 до n (Замудренный)
        {
            int x;
            string y = null;
            int m = n;
            int count = 0;
            while (m > 0)
            {
                m /= 10;
                count++;
            } //Количество чисел в номере
            if (n == 0) 
            {
                return 0;
            } //Условие для 0
            else if (n > 0 && n <= 10)
            {
                if (n > n / 2)
                {
                    if (n % 2 != 0)
                    {
                        x = (DateTime.Now.Millisecond * 13) % 10;
                        return x;
                    }
                    else if (n % 2 == 0)
                    {
                        x = (DateTime.Now.Millisecond * 42) % 10;
                        return x;
                    }
                }
                else if (n < n / 2)
                {
                    if (n % 2 != 0)
                    {
                        x = (DateTime.Now.Millisecond * 79) % 10;
                        return x;
                    }
                    else if (n % 2 == 0)
                    {
                        x = (DateTime.Now.Millisecond * 86) % 10;
                        return x;
                    }
                }
            } //Условие до 10
            else if (n > 9 && n <= 100)
            {
                if (n > n / 2)
                {
                    if (n % 2 != 0)
                    {
                        x = (DateTime.Now.Millisecond * 13) % 100;
                        return x;
                    }
                    else if (n % 2 == 0)
                    {
                        x = (DateTime.Now.Millisecond * 42) % 100;
                        return x;
                    }
                }
                else if (n < n / 2)
                {
                    if (n % 2 != 0)
                    {
                        x = (DateTime.Now.Millisecond * 79) % 100;
                        return x;
                    }
                    else if (n % 2 == 0)
                    {
                        x = (DateTime.Now.Millisecond * 86) % 100;
                        return x;
                    }
                }
            } //Условие до 100
            else if (n > 100 && n <= 1000)
            {
                if (n > n / 2)
                {
                    if (n % 2 != 0)
                    {
                        x = (DateTime.Now.Millisecond * 13) % 1000;
                        return x;
                    }
                    else if (n % 2 == 0)
                    {
                        x = (DateTime.Now.Millisecond * 42) % 1000;
                        return x;
                    }
                }
                else if (n < n / 2)
                {
                    if (n % 2 != 0)
                    {
                        x = (DateTime.Now.Millisecond * 79) % 1000;
                        return x;
                    }
                    else if (n % 2 == 0)
                    {
                        x = (DateTime.Now.Millisecond * 86) % 1000;
                        return x;
                    }
                }
            } //Условие до 1000 (т.к. милисекунды возвращают трехзначные числа)
            else if (count > 3 && (count % 3 == 0))
            {
                for (int i = 0; i < (count / 2); i++)
                {
                    if (n > n / 2)
                    {
                        if (n % 2 != 0)
                        {
                            y += ((DateTime.Now.Millisecond * 13) % 1000).ToString();
                        }
                        else if (n % 2 == 0)
                        {
                            y += ((DateTime.Now.Millisecond * 42) % 1000).ToString();
                        }
                    }
                    else if (n < n / 2)
                    {
                        if (n % 2 != 0)
                        {
                            y += ((DateTime.Now.Millisecond * 79) % 1000).ToString();
                        }
                        else if (n % 2 == 0)
                        {
                            y += ((DateTime.Now.Millisecond * 86) % 1000).ToString();
                        }
                    }
                }
                return int.Parse(y);
            } //Условие для номера с количеством чисел кратного 3
            else if (count > 3 && (count % 3 == 1))
            {
                for (int i = 0; i < (count / 2); i++)
                {
                    if (n > n / 2)
                    {
                        if (n % 2 != 0)
                        {
                            y += ((DateTime.Now.Millisecond * 13) % 1000).ToString();
                        }
                        else if (n % 2 == 0)
                        {
                            y += ((DateTime.Now.Millisecond * 42) % 1000).ToString();
                        }
                    }
                    else if (n < n / 2)
                    {
                        if (n % 2 != 0)
                        {
                            y += ((DateTime.Now.Millisecond * 79) % 1000).ToString();
                        }
                        else if (n % 2 == 0)
                        {
                            y += ((DateTime.Now.Millisecond * 86) % 1000).ToString();
                        }
                    }
                }
                if (n > n / 2)
                {
                    if (n % 2 != 0)
                    {
                        y += ((DateTime.Now.Millisecond * 42) % 10).ToString();
                    }
                    else if (n % 2 == 0)
                    {
                        y += ((DateTime.Now.Millisecond * 13) % 10).ToString();
                    }
                }
                else if (n < n / 2)
                {
                    if (n % 2 != 0)
                    {
                        y += ((DateTime.Now.Millisecond * 86) % 10).ToString();
                    }
                    else if (n % 2 == 0)
                    {
                        y += ((DateTime.Now.Millisecond * 79) % 10).ToString();
                    }
                }
                return int.Parse(y);
            } //Условие для номера с количеством чисел не кратного 3, с остатком 1
            else if (count > 3 && (count % 3 == 2))
            {
                for (int i = 0; i < (count / 2); i++)
                {
                    if (n > n / 2)
                    {
                        if (n % 2 != 0)
                        {
                            y += ((DateTime.Now.Millisecond * 13) % 1000).ToString();
                        }
                        else if (n % 2 == 0)
                        {
                            y += ((DateTime.Now.Millisecond * 42) % 1000).ToString();
                        }
                    }
                    else if (n < n / 2)
                    {
                        if (n % 2 != 0)
                        {
                            y += ((DateTime.Now.Millisecond * 79) % 1000).ToString();
                        }
                        else if (n % 2 == 0)
                        {
                            y += ((DateTime.Now.Millisecond * 86) % 1000).ToString();
                        }
                    }
                }
                if (n > n / 2)
                {
                    if (n % 2 != 0)
                    {
                        y += ((DateTime.Now.Millisecond * 42) % 100).ToString();
                    }
                    else if (n % 2 == 0)
                    {
                        y += ((DateTime.Now.Millisecond * 13) % 100).ToString();
                    }
                }
                else if (n < n / 2)
                {
                    if (n % 2 != 0)
                    {
                        y += ((DateTime.Now.Millisecond * 86) % 100).ToString();
                    }
                    else if (n % 2 == 0)
                    {
                        y += ((DateTime.Now.Millisecond * 79) % 100).ToString();
                    }
                }
                return int.Parse(y);
            } //Условие для номера с количеством чисел не кратного 3, с остатком 2
            return 0;
        }
        static void Main(string[] args)
        {
            Console.Write("Введите число: "); //Задание 14. Вывод автоморфных чисел
            int N = int.Parse(Console.ReadLine());
            Automorf(N);

            Console.WriteLine(); //отступ

            Random random = new Random(); //Задание 13. Вывод базовых и собственных псевдослучайных чисел

            Console.WriteLine("Базовый рандом:");
            for (int i = 0; i < 100; i++)
            {
                Console.Write($"{random.Next(100)} ");
            }
            Console.WriteLine();
            Console.WriteLine("Мой рандом:");
            for (int i = 0; i < 100; i++)
            {
                Console.Write($"{MyRandom(100)} ");
            }

            Console.ReadKey();
        }
    }
}
