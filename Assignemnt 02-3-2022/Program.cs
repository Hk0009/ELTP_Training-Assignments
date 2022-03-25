using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using Assignemnt_02_3_2022.Data;
using Assignemnt_02_3_2022.Operations;

namespace Assignemnt_02_3_2022
{
    internal class Program
    {
        static void Main(string[] args)
        {
           Employee employee = new Employee();
var employee_Operation = new Employee_operation();

            //Console.WriteLine("Add new Record");
            //var empNew1 = new Employee();
            //Console.WriteLine("enter EmpNO");
            //empNew1.EmpNo = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine("enter EmpName");
            //empNew1.EmpName = Console.ReadLine();
            //Console.WriteLine("enter Salary");
            //empNew1.Salary = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine("enter Designation");
            //empNew1.Designation = Console.ReadLine();
            //Console.WriteLine("enter DeptNo");
            //empNew1.DeptNo = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine("enter Email");
            //empNew1.Email = Console.ReadLine();
            //var result1 = employee_Operation.addsync(empNew1);
            //if (result1 == null)
            //{
            //    Console.WriteLine("Faild...........");
            //}
            //else
            //{
            //    Console.WriteLine("Data Added Successfully.......");
            //}
            //Console.WriteLine("-------------------------------------------------------------------------------------------");
            //var result =employee_Operation.getdata().Result;

            //Console.WriteLine("List of Departments");
            //foreach (var item in result.Employees)
            //{
            //    Console.WriteLine($"EmpNo : {item.EmpNo}, EmpName: {item.EmpName}");
            //}
            Console.WriteLine("Enter Employee Id to be updated");
            int id = int.Parse(Console.ReadLine());


            Console.WriteLine("Enter Updated Employee name");
            string Updatedname = Console.ReadLine();

            Console.WriteLine("Enter Updated Salary");
            int UpdatedSalary = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Updated Dept number");
            int UpdatedDeptNo = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Updated Designation");
            string UpdatedDesignation = Console.ReadLine();

            Console.WriteLine("Enter Updated Email");
            string UpdatedEmail = Console.ReadLine();

            var UpdatednewEmp = new Employee()
            {
                EmpNo = id,
                EmpName = Updatedname,
                Salary = UpdatedSalary,
                Designation = UpdatedDesignation,
                DeptNo = UpdatedDeptNo,
                Email = UpdatedEmail

            };
            var u =  employee_Operation.updateAsync(id,employee);
           // break;
           if(u== null)
            {
                Console.WriteLine("Cannot update");
            }
           else
            {
                Console.WriteLine(" updated");

            };


            Console.ReadLine(); 
        }
    }
}
