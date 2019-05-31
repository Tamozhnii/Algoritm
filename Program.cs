using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritm
{
    class Program
    {
        public static void GrafCreator(out object[] tops, out int[,] arcs, int top)
        {
            Random random = new Random();
            tops = new object[top];
            for (int i = 0; i < top; i++)
            {
                tops[i] = i + 1;
            }
            int maxArc = 0;
            for (int j = top; j > 0; j--)
            {
                maxArc += j;
            }
            int arc = random.Next(top - 1, maxArc);
            Arcs(out arcs, arc, top);
        }

        public static void Arcs(out int[,] arcs, int arc, int top)
        {
            Random random = new Random();
            arcs = new int[top + 1, top + 1];
            for (int i = 0; i <= top; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    arcs[i, j] = 0;
                }
            }
            for (int k = 0; k < arc; k++)
            {
                int x = random.Next(1, top);
                int y = random.Next(1, top);
                if(x != y && y > x)
                {
                    arcs[x, y] = random.Next(1, 10);
                    arcs[y, x] = arcs[x, y];
                }
            }
        }

        public static void Bypass(ref Stack<object> turn, ref object[,] PR, int[,] arcs)
        {
            while (turn != null)
            {
                int x = int.Parse(turn.Pop().ToString());
                for (int j = 1; j < PR.Length; j++)
                {
                    if (arcs[x, j] != 0
                        && arcs[x, j] < (int.Parse(PR[1, j - 1].ToString()) + int.Parse(PR[1, x].ToString()))
                        && PR[1, j - 1] != PR[1, x])
                    {
                        PR[1, j - 1] = arcs[x, j] + int.Parse(PR[1, x].ToString());
                        turn.Push(PR[0, j - 1]);
                    }
                }
            }
        }

        public static int AlgoritmDijkstra(object[] grafs, int[,] arcs, int a, int b)
        {
            object[,] PR = new object[2, grafs.Length];
            for (int i = 0; i < grafs.Length; i++)
            {
                PR[0, i] = grafs[i];
                PR[1, i] = 100000;
            }
            Stack<object> turn = new Stack<object>();
            PR[1, a] = 0;
            for (int j = 1; j < grafs.Length; j++)
            {
                if (arcs[a, j] != 0 && arcs[a, j] < int.Parse(PR[1, j - 1].ToString()))
                {
                    PR[1, j - 1] = arcs[a, j] + int.Parse(PR[1, a].ToString());
                    turn.Push(PR[0, j - 1]);
                }
            }
            Bypass(ref turn, ref PR, arcs);
            return int.Parse(PR[1, b].ToString());
        }

        static void Main(string[] args)
        {
            int[,] arcs = null;
            object[] tops = null;
            int top;
            Console.WriteLine("Введите количество вершин:");
            int.TryParse(Console.ReadLine(), out top);

            GrafCreator(out tops, out arcs, top);

            Console.WriteLine("Вершины:");
            foreach (int item in tops)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
            Console.WriteLine("Связи: (столбец - номер текущего объекта,\n " +
                "строка - номер объекта с которым связан текущий объект\n " +
                "цифра - расстояние между объектами\n 0 - отсутствие связи");
            for (int i = 0; i < top; i++)
            {
                for (int j = 0; j < top; j++)
                {
                    Console.Write($"{arcs[i, j]} ");
                }
                Console.WriteLine();
            }

            Console.WriteLine("Введите с какого до какого объекта вы хотите найти кратчайший путь");
            int a = 0, b = 0;
            do
            {
                Console.Write("С точки: ");
                int.TryParse(Console.ReadLine(), out a);
                Console.Write("До точки: ");
                int.TryParse(Console.ReadLine(), out b);
            } while (a < 0 || a > top || b < 0 || b > top);

            int x = AlgoritmDijkstra(tops, arcs, a, b);
            Console.WriteLine($"Кратчайший путь равен {x}");

            Console.ReadKey();
        }
    }
}
