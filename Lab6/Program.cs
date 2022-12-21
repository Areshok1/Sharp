using System;

namespace tmp
{
    class Lab6
    {
        static void Swap<T>(ref T a, ref T b)
        {
            T tmp = a;
            a = b;
            b = tmp;
        }

        static int IntPow(int a, int pow)
        {
            if (pow < 0)
                throw new Exception("Power is less than zero");
            if (pow == 0)
                return 1;
            return a * IntPow(a, pow - 1);
        }

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

        // =====  REVERSE INT  	===== //

        static void Reverse(ref int a)
        {
            int tmpa = a;
            int b = 0;
            int degree = IntLength(a) - 1;

            while (tmpa != 0)
            {
                b += (tmpa % 10) * IntPow(10, degree--);
                tmpa /= 10;
            }

            a = b;
        }

        // =====  REVERSE FLOAT  	===== //

        static void CutZeroes(ref int a)
        {
            if (a % 10 != 0)
                return;
            a /= 10;
            CutZeroes(ref a);
        }

        static int GetInteger(double a) => (int)a;

        static int GetFractional(double a, int precision = 6)
        {
            int integer = (int)a; // get integer value
            int fractional = (int)(
              Math.Round(
                a - (double)integer,
                precision
              ) * IntPow(10, precision) // (123.45 - 123.00) * 10⁶ = 0.45 * 10⁶ = 450000
            ); // отримати цифри після точки

            CutZeroes(ref fractional); //

            return fractional;
        }

        static void Reverse(ref double a, int precision = 6, bool partial = false)
        {
            int integer = GetInteger(a);
            int fractional = GetFractional(a, precision);

            Reverse(ref integer);
            Reverse(ref fractional);

            // два варіанти: частковий і НЕ частковий
            // часткове змінює число повністю, а НЕ часткове змінює ціле та дробове окремо
            if (partial)
                a = (double)integer + (double)fractional / IntPow(10, IntLength(fractional));
            else
                a = (double)fractional + (double)integer / IntPow(10, IntLength(integer));
        }

        // =====  REVERSE STRING  	===== //

        static bool Contains(string s, char c)
        {
            foreach (var e in s)
                if (e == c)
                    return true;
            return false;
        }

        static void Reverse(ref string s, bool partial = false)
        {
            string tmps = "";

            if (partial)
            {
                int startIdx = 0, endIdx = 0;
                bool flag = false;
                string magic = ".,/|\\_-";

                for (int i = 0; i < s.Length; i++, startIdx = ++endIdx)
                {
                    while (i < s.Length && !Contains(magic, s[i]))
                    {
                        flag = true;
                        endIdx = i;
                        i++;
                    }
                    if (flag)
                    {
                        flag = false;
                        i--;
                    }
                    for (int j = startIdx; j <= endIdx; j++)
                        tmps += s[startIdx + endIdx - j];
                }
            }
            else
            {
                int len = s.Length;

                for (int i = 0; i < len; i++)
                {
                    tmps += s[len - i - 1];
                }
            }
            s = tmps;
        }

        // =====  REVERSE ARRAY  	===== //

        static void PrintArr<T>(T[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
                Console.Write($"{arr[i]},");
            Console.Write(arr[arr.Length - 1]);
        }

        static void Reverse<T>(ref T[] arr, out T[] outArr)
        {
            int len = arr.Length;
            outArr = new T[len];
            for (int i = 0; i < len; i++)
                outArr[i] = arr[len - i - 1];
        }

        // ========================== RECURSION ========================== //

        // =====  REVERSE INT  	===== //

        static int ReverseRecursive(int a, int degree)
        {
            if (degree == 0)
                return a;
            return (a % 10) * IntPow(10, degree) + ReverseRecursive(a / 10, degree - 1);
        }

        static void ReverseRecursive(ref int a)
        {
            a = ReverseRecursive(a, IntLength(a) - 1);
        }

        // ===== REVERSE FLOAT ===== //

        static void ReverseRecursive(ref double a, int precision = 6, bool partial = false)
        {
            int integer = GetInteger(a);
            int fractional = GetFractional(a);

            ReverseRecursive(ref integer);
            ReverseRecursive(ref fractional);

            // два варіанти: частковий і НЕ частковий
            // часткове змінює число повністю, а НЕ часткове змінює ціле та дробове окремо
            if (partial)
                a = (double)integer + (double)fractional / IntPow(10, IntLength(fractional));
            else
                a = (double)fractional + (double)integer / IntPow(10, IntLength(integer));
        }

        // ===== REVERSE STRING ===== //
        static string ReverseRecursive(string s, int i)
        {
            if (i == 0)
                return $"{s[0]}";
            return s[i] + ReverseRecursive(s, i - 1);
        }

        static void ReverseRecursive(ref string s)
        {
            s = ReverseRecursive(s, s.Length - 1);
        }

        // ===== REVERSE ARRAY ===== //

        static void ReverseRecursive<T>(T[] arr, T[] outArr, int i)
        {
            if (i < 0)
                return;
            outArr[i] = arr[arr.Length - i - 1];
            ReverseRecursive(arr, outArr, i - 1);
        }

        static void ReverseRecursive<T>(T[] arr, out T[] outArr)
        {
            outArr = new T[arr.Length];
            ReverseRecursive(arr, outArr, arr.Length - 1);
        }

        static void Main()
        {
            Console.WriteLine("Iterative way =======================================");

            // Reverse int value
            int a = 1234;
            Console.Write($"1 [{a.GetType().Name}]\t{a} --> ");
            Reverse(ref a);
            Console.WriteLine(a);

            // Reverse float value
            double d1 = 123.456;
            Console.Write($"2.1 [{d1.GetType().Name}]\t{d1} --> ");
            Reverse(ref d1, partial: false);
            Console.WriteLine(d1);

            // Reverse float value partially
            double d2 = 123.456;
            Console.Write($"2.2 [{d2.GetType().Name}]\t{d2} --> ");
            Reverse(ref d2, partial: true);
            Console.WriteLine(d2);

            // Reverse string
            string s1 = "ABC.DEFG.,HI,./G";
            Console.Write($"3 [{s1.GetType().Name}]\t{s1} --> ");
            Reverse(ref s1);
            Console.WriteLine(s1);
            // Reverse string partially
            string s2 = "ABC.DEFG.,HI,./G";
            Console.Write($"4 [{s2.GetType().Name}]\t{s2} --> ");
            Reverse(ref s2, partial: true);
            Console.WriteLine(s2);

            // Reverse array
            int[] arr = new int[] { 1, 2, 3, 4, 5 };
            int[] outArr;
            Console.Write($"5 [{arr.GetType().Name}]\t");
            PrintArr(arr);
            Console.Write(" --> ");
            Reverse(ref arr, out outArr);
            PrintArr(outArr);
            Console.WriteLine();


            // ==========================
            Console.WriteLine("\nRecursive way =======================================");
            // ==========================

            // Reverse int value recursive
            Console.Write($"1 [{a.GetType().Name}]\t{a} --> ");
            ReverseRecursive(ref a);
            Console.WriteLine(a);

            // Reverse float value recursive
            Console.Write($"2.1 [{d1.GetType().Name}]\t{d1} --> ");
            ReverseRecursive(ref d1, partial: false);
            Console.WriteLine(d1);

            // Reverse float value recursive partially
            Console.Write($"2.2 [{d2.GetType().Name}]\t{d2} --> ");
            ReverseRecursive(ref d2, partial: true);
            Console.WriteLine(d2);

            // Reverse string recursive
            Console.Write($"3 [{s1.GetType().Name}]\t{s1} --> ");
            ReverseRecursive(ref s1);
            Console.WriteLine(s1);

            // Reverse array recursive
            Console.Write($"5 [{arr.GetType().Name}]\t");
            PrintArr(arr);
            Console.Write(" --> ");
            ReverseRecursive(arr, out outArr);
            PrintArr(outArr);
            Console.WriteLine();

        }

        static void Line(char c = '-')
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
