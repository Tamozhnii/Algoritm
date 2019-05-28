using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritm
{
    class Program
    {
        public static int HashSum(string x)
        {
            int sum = 0;
            int num;
            for (int i = 0; i < x.Length; i++)
            {
                num = (Convert.ToByte(x[i]) * 17 / 13);
            sum += num;
            }
            return sum;
        }

        static void Main(string[] args)
        {
            string x = Console.ReadLine();
            Console.WriteLine(HashSum(x));
            Console.ReadKey();
        }
    }
}
