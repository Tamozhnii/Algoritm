using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritm
{
    class Program
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
        }//Степень рекурсией

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
        }//Степень рекурсией со свойствами четности
        static void Main(string[] args)
        {
            string biNumber = null;
            Console.WriteLine(BiNumber(25, ref biNumber));

            Console.WriteLine(MyPow(-2, 3));
            Console.WriteLine(RecPow(-2, 3));
            Console.WriteLine(NewPow(-2, 9));

            Console.ReadKey();
        }
    }
}
