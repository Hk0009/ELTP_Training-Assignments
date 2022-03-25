using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment_02_03_2022.DataAccess;
using Assignment_02_03_2022.Models;

namespace Assignment_02_03_2022
{
    internal class Program
    {
        static async void Main(string[] args)
        {
            IDataAccess<Mydatabase, int> deptdb = new CRUDDEP();
            IDataAccess<ComEmployee, int> empdb = new CRUDEMP();

            var employees =await empdb.GetDataAsync();


            //ComEmployee employeee = new ComEmployee();


            foreach (var employee in employees)
            {
                Console.WriteLine($"{employee.EmpNo}   {employee.EmpName} {employee.Salary} {employee.Designation} {employee.DeptNo}  {employee.Email}");
            }
            Console.WriteLine("-------------------------------------------------------------------------------------------");
            Console.ReadLine();
        }
    }
}
