using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritm                              //Таможний П.И.
{
    class Program
    {
        public static void GrafCreator(ref object[] tops, ref int[,] arcs)
        {
            Random random = new Random();
            for (int i = 0; i < tops.Length; i++)
            {
                tops[i] = i + 1;
            }
            int maxArc = 0;
            for (int j = tops.Length; j > 0; j--)
            {
                maxArc += j;
            }
            int arc = random.Next(tops.Length - 1, maxArc);
            Arcs(ref arcs, arc, tops.Length);
        } //Создание вершин

        public static void Arcs(ref int[,] arcs, int arc, int top)
        {
            Random random = new Random();
            for (int i = 0; i <= top; i++)
            {
                for (int j = 0; j <= top; j++)
                {
                    arcs[i, j] = 0;
                }
            }
            for (int k = 0; k < arc; k++)
            {
                int x = 0, y = 0;
                while (x == y && y >= x)
                {
                    x = random.Next(1, top + 1);
                    y = random.Next(1, top + 1);
                    if (x != y && y > x)
                    {
                        arcs[x, y] = random.Next(1, 10);
                        arcs[y, x] = arcs[x, y];
                    }
                }
            }
        } //Создание дуг со значениями от 1 до 10

        public static void Bypass(ref Stack<object> turn, ref object[,] PR, int[,] arcs)
        {
            while (turn.Count != 0)
            {
                int x = int.Parse(turn.Pop().ToString());
                for (int j = 1; j <= PR.Length/2; j++)
                {
                    if (arcs[x, j] != 0 && 
                        (arcs[x, j] + int.Parse(PR[1, x - 1].ToString()) < int.Parse(PR[1, j - 1].ToString())
                        && PR[1, j - 1] != PR[1, x - 1]))
                    {
                        PR[1, j - 1] = arcs[x, j] + int.Parse(PR[1, x - 1].ToString());
                        turn.Push(PR[0, j - 1]);
                    }
                }
            }
        } //Метод Дейстра определения кратчайшего пути до всех вершин

        public static int AlgoritmDijkstra(object[] grafs, int[,] arcs, int a, int b)
        {
            object[,] PR = new object[2, grafs.Length];
            for (int i = 0; i < grafs.Length; i++)
            {
                PR[0, i] = grafs[i];
                PR[1, i] = 100000;
            }
            Stack<object> turn = new Stack<object>();
            PR[1, a - 1] = 0;
            turn.Push(a);
            Bypass(ref turn, ref PR, arcs);
            return int.Parse(PR[1, b - 1].ToString());
        } //Кратчайший путь из вершины a в вершину b

        static void Main(string[] args)
        {
            int top;
            Console.WriteLine("Введите количество вершин:");
            int.TryParse(Console.ReadLine(), out top);
            int[,] arcs = new int[top + 1, top + 1];
            object[] tops = new object[top];
            GrafCreator(ref tops, ref arcs); //Создание графа

            Console.WriteLine("Вершины:");
            foreach (int item in tops)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
            Console.WriteLine("Связи: цифра - расстояние между объектами\n 0 - отсутствие связи");
            for (int i = 0; i <= top; i++)
            {
                for (int j = 0; j <= top; j++)
                {
                    Console.Write($"{arcs[i, j]} ");
                }
                Console.WriteLine();
            } //Отображение матрицы смежности

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
