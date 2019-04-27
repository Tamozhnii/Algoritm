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
        static void Main(string[] args)
        {
            //Задание 14. Вывод автоморфных чисел
            Console.Write("Введите число: ");
            int N = int.Parse(Console.ReadLine());
            Automorf(N);

            Console.ReadKey();
        }
    }
}
