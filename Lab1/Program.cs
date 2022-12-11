using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    internal class Program
    {
        static int TryCatchInt(int a)
        {
            while (true)
            {
                try
                {
                    a = int.Parse(Console.ReadLine());
                    return a;
                }
                catch
                {
                    Console.WriteLine("Enter number!");
                }
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("2x^4-3x^3+4x^2-5x+6");
            int x = 0;
            Console.Write($"Enter x: ");
            x = TryCatchInt(x);
            double result = 2 * Math.Pow(x, 4) - 3 * Math.Pow(x,3) + 4 * Math.Pow(x, 2)-5*x+6 ;
            Console.WriteLine("Answer: "+ result);
        }
    }
}
