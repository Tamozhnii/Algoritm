using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritm                         //Таможний П.И.
{
    class Program
    {
        //Задание 3. Написать программу, которая определяет, является ли введённая скобочная последовательность правильной. Примеры правильных скобочных выражений – (), ([])(), {}(), ([{}]), неправильных – )(, ())({), (, ])}), ([(]), для скобок – [, (, {.

        static bool Bracket(string formula)
        {
            char[] bracket = new char[100];
            int count = 0;
            bracket[count] = ' ';
            foreach (char v in formula)
            {
                switch (v)
                {
                    case '(':
                        count++;
                        bracket[count] = v;
                        Console.WriteLine($"{v}, count = {count}");
                        break;
                    case '[':
                        count++;
                        bracket[count] = v;
                        Console.WriteLine($"{v}, count = {count}");
                        break;
                    case '{':
                        count++;
                        bracket[count] = v;
                        Console.WriteLine($"{v}, count = {count}");
                        break;
                    case ')':
                        if (bracket[count] == '(')
                        {
                            count--;
                            Console.WriteLine($"{v}, count = {count}");
                            break;
                        }
                        break;
                    case ']':
                        if (bracket[count] == '[')
                        {
                            count--;
                            Console.WriteLine($"{v}, count = {count}");
                            break;
                        }
                        break;
                    case '}':
                        if (bracket[count] == '{')
                        {
                            count--;
                            Console.WriteLine($"{v}, count = {count}");
                            break;
                        }
                        break;
                    default:
                        break;
                }
            }
            if (count == 0)
            {
                return true;
            }
            else return false;
        }

        //Задание 5. *Реализовать алгоритм перевода из инфиксной записи арифметического выражения в постфиксную.

        static void Infix(string formula)
        {
            if (Bracket(formula))
            {


            }
            else Console.WriteLine("Error formula");
        }

        static void Main(string[] args)
        {
            string a = "{[()]}((()))";
            Console.WriteLine(Bracket(a));
            Console.ReadKey();
        }
    }
}
