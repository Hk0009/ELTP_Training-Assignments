using System;

namespace Assignment_8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employees employee = new Employees();
            Employee_operation operation = new Employee_operation();
            operation.CalculateTax(employee);
            
            
        }
    }
}
