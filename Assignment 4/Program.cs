using System;

namespace Assignment_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the angle for trignometric operations");
           double angle=Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Sine value of {0} is {1}", angle, Math.Sin(angle));
            Console.WriteLine("Cosine value of {0} is {1}", angle, Math.Cos(angle));
            Console.WriteLine("Tangent value of {0} is {1}", angle, Math.Tan(angle));
            Console.WriteLine("Enter Two integer for further math operations");
            Console.WriteLine("Enter Vale of a");
            double a=Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter Vale of b");
            double b = Convert.ToDouble(Console.ReadLine());

            double abs=Math.Abs(a);

            Console.WriteLine($"Abstract of {a} is {abs}\n");
            double sqrt_ =Math.Sqrt(a);
            Console.WriteLine($"SquareRoot of {a} is {sqrt_}\n");
            

            double Round_=Math.Round(a);
            Console.WriteLine($"Round of {a} is {Round_}\n");

            double Max=Math.Max(a, b);
            Console.WriteLine($"Max no from {a} and {b}={Max}");
            double Min=Math.Min(a, b);
            Console.WriteLine($"Min no from {a} and {b}={Min}");











        }
    }
}
