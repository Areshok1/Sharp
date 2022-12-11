using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab4
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
            Console.Write("Enter size array: ");
            int size = 0;
            size = TryCatchInt(size);
            int[] arr = new int [size];
            Random rand = new Random();
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rand.Next(0, 20);
            }

            Line();
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i]+"\t");
            }
            Console.WriteLine();
            Console.WriteLine("Growing: " + growing(arr));
            Console.WriteLine("Descending: " + descending(arr));
        }
        static int growing(int[] arr)
        {
            int growing = 0;
            int count = 0;
            int h = 0;
            int u = 0;
            while (u < arr.Length - 1)
            {
                count = 0;
                while (h < arr.Length - 1 && arr[h] < arr[h + 1])
                {
                    h++;
                    count++;
                }
                if (count > 0)
                    growing++;
                else
                    h++;
                u++;
            }
            return growing;
        }
        static int descending(int[] arr)
        {
            int descending = 0;
            int count = 0;
            int h = 0;
            int u = 0;
            while (u < arr.Length - 1)
            {
                count = 0;
                while (h < arr.Length - 1 && arr[h] > arr[h + 1])
                {
                    h++;
                    count++;
                }
                if (count > 0)
                    descending++;
                else
                    h++;
                u++;
            }
            return descending;
        }
        static void Line(char c = '-') // prints out console-width amount of "c" value
        {
            int w = Console.WindowWidth;
            for (int i = 0; i < w; i++)
            {
                Console.Write(c);
            }
            Console.WriteLine();
        }
    }
}
