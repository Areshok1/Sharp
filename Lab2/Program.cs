using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    class Program
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
            int nn=0, nk=0;
            double res = 0;
            Console.Write("from: ");
            nn = TryCatchInt(nn);
            Console.Write("to: ");
            nk = TryCatchInt(nk);
            for (int k = nn; k <= nk; k++)
            {
                res += (Math.Pow(k, 2) + Math.Pow(-1, Math.Pow(k, 2) + Math.Pow(-1, k) * k) * k) / (3 * Math.Pow(k, 2) + 5);
            }
            Console.WriteLine($"Result: {res}");
        }
    }
}