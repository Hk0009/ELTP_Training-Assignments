using System;

namespace Assignemnt_14_feb_Serialization
{
    internal class Program
    {
        static void Main(string[] args)
        {
           Employee_data employee = new Employee_data();
            
           FileOperation fileOperation = new FileOperation();
            fileOperation.CalculateTax(employee);
        }
    }
}
