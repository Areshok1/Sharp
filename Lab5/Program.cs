using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    internal class Program
    {
        static int MaxDiagonalsMain(int[,]arr, int num)
        {
            int maxdiagonal;
            if (num > arr.GetLength(1))
            {
                num = num - arr.GetLength(1);
                maxdiagonal = arr[0, num];
                for (int i = 0; i < arr.GetLength(0); i++)
                {
                    if (i < arr.GetLength(1) && num < arr.GetLength(1) && arr[i, num] > maxdiagonal)
                    {
                        maxdiagonal = arr[i, num];
                    }
                    num++;
                }
                return maxdiagonal;
            }
            else
            {
                num = arr.GetLength(1) - num;
                maxdiagonal = arr[num, 0];
                for (int i = 0; i < arr.GetLength(0); i++)
                {
                    if (i < arr.GetLength(1) && num < arr.GetLength(1) && arr[num, i] > maxdiagonal)
                        maxdiagonal = arr[num, i];
                    num++;
                }
                return maxdiagonal;
            }
        }
        static int MinDiagonalsMain(int[,] arr, int num)
        {
            int mindiagonal;
            if (num > arr.GetLength(1))
            {
                num = num - arr.GetLength(1);
                mindiagonal = arr[0, num];
                for (int i = 0; i < arr.GetLength(0); i++)
                {
                    if (i < arr.GetLength(1) && num < arr.GetLength(1) && arr[i, num] < mindiagonal)
                    {
                        mindiagonal = arr[i, num];
                    }
                    num++;
                }
                return mindiagonal;
            }
            else
            {
                num = arr.GetLength(1) - num;
                mindiagonal = arr[num, 0];
                for (int i = 0; i < arr.GetLength(0); i++)
                {
                    if (i < arr.GetLength(1) && num < arr.GetLength(1) && arr[num, i] < mindiagonal)
                        mindiagonal = arr[num, i];
                    num++;
                }
                return mindiagonal;
            }
        }
        static int MaxDiagonalsSide(int[,]arr, int num)
        {
            int maxdiagonal;
            if (num > arr.GetLength(1))
            {
                num = num - arr.GetLength(1);
                maxdiagonal = arr[0, num];
                for (int i = 0; i < arr.GetLength(0); i++)
                {
                    if (i < arr.GetLength(1) && num >= 0 && arr[i, num] > maxdiagonal)
                    {
                        maxdiagonal = arr[i, num];
                    }
                    num--;
                }
                return maxdiagonal;
            }
            else
            {
                num = arr.GetLength(1) - num;
                int lastnum = arr.GetLength(1);
                maxdiagonal = arr[num, lastnum];
                for (int i = 0; i < arr.GetLength(0); i++)
                {
                    if (i < arr.GetLength(1) && lastnum >= 0 && arr[num, lastnum] > maxdiagonal && num < arr.GetLength(1)&&lastnum<arr.GetLength(1))
                        maxdiagonal = arr[num, i];
                    num--;
                    lastnum--;
                }
                return maxdiagonal;
            }
        }
        static int MinDiagonalsSide(int[,] arr, int num)
        {
            int lastnum = arr.GetLength(1)-1;
            int mindiagonal = arr[num, lastnum];
            if (num > arr.GetLength(1))
            {
                num = num - arr.GetLength(1);
                mindiagonal = arr[0, num];
                for (int i = 0; i < arr.GetLength(0); i++)
                {
                    if (i < arr.GetLength(1) && num >= 0 && arr[i, num] < mindiagonal)
                    {
                        mindiagonal = arr[i, num];
                    }
                    num--;
                }
                return mindiagonal;
            }
            else
            {
                num = arr.GetLength(1) - num;
                mindiagonal = arr[num, lastnum];
                for (int i = 0; i < arr.GetLength(0); i++)
                {
                    if (i < arr.GetLength(1) && num <= 0 && arr[num, i] < mindiagonal)
                        mindiagonal = arr[num, lastnum];
                    num++;
                    lastnum--;
                }
                return mindiagonal;
            }
        }
        static void fillarr(int[,] arr)
        {
            Random rand = new Random();
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    arr[i, j] = rand.Next(1, 20);
                }
            }
        }
        static void outarr(int[,] arr,string side)
        {
            Console.Write("Numers");
            int num = arr.GetLength(0);
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                Console.Write($"\t#{num}");
                num++;
            }
            Console.WriteLine();
            num = arr.GetLength(0);
            if (side == "main")
                for (int i = 0; i < arr.GetLength(0); i++)
                {
                    Console.Write("#" + num);
                    for (int j = 0; j < arr.GetLength(1); j++)
                    {
                        Console.Write("\t" + arr[i, j]);
                    }
                    Console.WriteLine();
                    num--;
                }
            else
            {
                for (int i = 0; i < arr.GetLength(0); i++)
                {
                    for (int j = 0; j < arr.GetLength(1); j++)
                    {
                        Console.Write("\t" + arr[i, j]);
                    }
                    Console.WriteLine("\t#" + num);
                    num--;
                }
            }
        }
        static void Main(string[] args)
        {
            Console.Write("Size: ");
            int size = int.Parse(Console.ReadLine());
            int[,] arr = new int[size, size];
            Console.WriteLine("What diagonal (side or main)?");
            string side = Console.ReadLine();
            fillarr(arr);
            outarr(arr,side);
            Console.Write("numer diagonal: ");
            int numer = int.Parse(Console.ReadLine());
            if (side == "main")
            {
                Console.WriteLine("min: " + MinDiagonalsMain(arr, numer));
                Console.WriteLine("max: " + MaxDiagonalsMain(arr,numer));
            }
            if (side == "side")
            {
                Console.WriteLine("min: " + MinDiagonalsSide(arr, numer));
                Console.WriteLine("max: " + MaxDiagonalsSide(arr, numer));
            }
                

        }
    }
}
