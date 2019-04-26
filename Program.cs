using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritm
{                               // Таможний П.И.
    class Program
    {
        static public void Automorf(int n) //Определение автоморфных чисел
        {
            string w = null;
            string m = null;
            Stack<double> stack = new Stack<double>();
            for (int i = 1; i <= n; i++)
            {
                int pow = Convert.ToInt32(Math.Pow(i, 2));
                while (pow > 0)
                {
                    stack.Push(pow % 10);
                    pow /= 10;
                }
                for (int j = 0; j <= (i.ToString()).Length; j++)
                {
                    m += stack.Pop().ToString();
                }
                int e = int.Parse(m);
                while (e > 0)
                {
                    w += e % 10;
                    e /= 10;
                }
                if (w == n.ToString())
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
