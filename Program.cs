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
            List<char> backetFormul;
            List<char> operand;
            List<string> postfixFormul;
            if (Bracket(formula))
            {
                foreach (char i in formula)
                {
                    if (i == '(')
                    {
                        int count = 0;
                        backetFormul = new List<char>();
                        do
                        {
                            backetFormul.Add(i);
                            switch (i)
                            {
                                case '(':
                                    count++;
                                    break;
                                case ')':
                                    count--;
                                    break;
                                default:
                                    break;
                            }
                        } while (count > 0);
                        backetFormul.RemoveAt(0);
                        int last = backetFormul.Count - 1;
                        backetFormul.RemoveAt(last);
                        Infix(backetFormul.ToString());
                    }
                }
                foreach (char i in formula)
                {
                    postfixFormul = new List<string>();
                    if(i == '^')
                    {
                        int a = formula.LastIndexOf(i);
                        operand = new List<char>();
                        for (int g = a + 2; g < formula.Length; g++)
                        {
                            if (formula[g] != ' ')
                            {
                                operand.Add(formula[g]);
                            }
                            else
                            {
                                string operandNumber = null;
                                foreach (char item in operand)
                                {
                                    operandNumber += item;
                                }
                                postfixFormul.Add($"{operandNumber} ");
                                operand.Clear();
                                break;
                            }
                        }
                        for (int j = a - 2; j >= 0; j--)
                        {
                            if(formula[j] != ' ')
                            {
                                operand.Add(formula[j]);
                            }
                            else
                            {
                                string operandNumber = null;
                                foreach(char item in operand)
                                {
                                    operandNumber += item;
                                }
                                postfixFormul.Add($"{operandNumber} ");
                                operand.Clear();
                                break;
                            }
                        }
                    }
                }
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
