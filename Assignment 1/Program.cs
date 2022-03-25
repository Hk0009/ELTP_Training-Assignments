using System;
namespace Assignment_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the asked values");
            int a, b;
            Console.WriteLine("Enter the value of a:");
            a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter b");
            b = Convert.ToInt32(Console.ReadLine());
            add(a, b);
            sub(a, b);
            mul(a, b);
            div(a, b);
            squareX(a, b);
            squareY(a, b);

        }
        static void add(int x, int y)
        {
            int z = 0;
            z = x + y;  //for addition
            Console.WriteLine("addition=" + z);
        }
        static void sub(int x, int y)
        {
            int z = 0;
            z = x - y; //for substraction
            Console.WriteLine("Substraction=" + z);
        }
        static void mul(int x, int y)
        {
            int z = 0;
            z = x * y; //for multiplication
            Console.WriteLine("Multiplication=" + z);
        }
        static void div(int x, int y)
        {
            int z = 0;
            z = x / y;  //for Division
            Console.WriteLine("Division =" + z);
        }
        static void squareX(int x, int y)
        {
            int z = 0;
            z = x * x;  //for Division
            Console.WriteLine("Square of x=" + z);
        }
        static void squareY(int x, int y)
        {
            int z = 0;
            z = y * y;  //for Division
            Console.WriteLine("Square of Y=" + z);
        }
    }
}