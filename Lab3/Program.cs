using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    internal class Program
    {
        static int IntLength(int a)
        {
            int n = 0;
            while (a != 0)
            {
                n++;
                a /= 10;
            }
            return n;
        }
        static void Main(string[] args)
        {
            int[] arr = new int[3];
            int h=0;
            int num;
            Console.WriteLine("Enter a three-digit number: ");
            while (true)
            {
                try
                {
                    num = int.Parse(Console.ReadLine());
                    if (IntLength(num)==3)
                    {
                        break;
                    }
                    throw new Exception();
                }
                catch
                {
                    Console.WriteLine("Enter a three-digit number!");
                }
            }
            while (num > 0)
            {
                arr[h] = num % 10;
                num /= 10;
                h++;
            }
            int k = arr[1] - arr[0];
            if (arr[2] - k == arr[1] && arr[1] - k == arr[0])
            {
                Console.WriteLine("True");
            }
            //else if (arr[0] - arr[1] - arr[2]==0)
            //{
            //    Console.WriteLine("True");
            //}
            else
            {
                Console.WriteLine("False");
            }
        }
    }
}
