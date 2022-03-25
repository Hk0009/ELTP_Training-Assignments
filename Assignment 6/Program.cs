using System;

namespace Assignment6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Math1 math = new Math1();
            string str = "harsh is ok. I am Hars.";

            Console.WriteLine($"addition of two no = {math.Add(2, 3)}");
            Console.WriteLine($"Power = {math.GetPower(2, 3, 0)}");
            Console.WriteLine($"Factorial={math.Factorial(2)}");
            Console.WriteLine($"Cube={math.Cube(8, 0)}");
            Console.WriteLine($"gap between = {math.NoOfSentences(str)}");
        }
    }
    public sealed class Math1
    {

        public int Add(int x, int y)
        {
            return x + y;
        }



    }
    public static class MyExtension
    {
        public static double GetPower(this Math1 mat, int x, int y, double z)
        {
            z = Math.Pow(x, y);
            return z;
        }
        public static int Factorial(this Math1 mat, int n)
        {
            int fact = 1;
            for (int i = 1; fact <= n; i++)
            {
                fact *= i;
            }
            return fact;
        }
        public static double Cube(this Math1 mat, int x, double z)
        {
            z = Math.Ceiling(Math.Pow(x, (double)1 / 3));
            return z;
        }
        public static int NoOfSentences(this Math1 mat, string str)
        {
            int count = 0;
            foreach (char c in str)
            {
                if (c == '.')
                    count++;
            }
            return count;
        }
    }
}   