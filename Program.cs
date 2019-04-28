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
        }
        static void Main(string[] args)
        {
            string biNumber = null;
            Console.Write(BiNumber(25, ref biNumber));
            Console.ReadKey();
        }
    }
}
