using System;

namespace Assignment2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("please write Add for addition , Sub for substraction, Mul for Multiplication, Div for division");
            int a, b;
            string c;

            Console.WriteLine("enter the value of a");
            a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("enter the value of b");
            b = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("please write Add for addition , Sub for substraction, Mul for Multiplication, Div for division");
            c = Convert.ToString(Console.ReadLine());
            int x = minicalculator(a, b, c);
            Console.WriteLine(x);


        }
        static int minicalculator(int a, int b, string c)
        {
            if (a <= 0 || b <= 0)
            {
                return 0;
            }
            else
            {
                if (c == "Add")
                {
                    return (a + b);
                }
                else
                {
                    return 0;
                }
                if (c == "Sub")
                {
                    return (a - b);
                }
                else
                {
                    return 0;
                }
                if (c == "Mul")
                {
                    return (a * b);
                }
                else
                {
                    return 0;
                }
                if (c == "Div")
                {
                    return (a / b);
                }
                else
                {
                    return 0;
                }
            }

        }

    }
}