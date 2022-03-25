using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Assignment_7
{
    internal class Program
    {
        static void Main(string[] args)
        {   Employee_Operation employee_Operation = new Employee_Operation();
            Employees employee = new Employees();
            Departments departments = new Departments();
            ModifiedEmployees modifiedEmployee = new ModifiedEmployees();
           int exit =0;
            char Input;
            do
            {
                Console.WriteLine("\n\nEnter 1 for Ascending order  Employee\n" +
                    "Enter 2 for Count Employee\n" +
                    "Enter 3 for sum of Employee by deptname \n" +
                    "Enter 4 for Max Salary per deptName\n" +
                    "Enter 5 for  Min Salary per deptName\n" +
                    "Enter 6 for Average per DeptName\n" +
                    "Enter 7 for  Designation Group \n" +
                    "Enter 8 for Display All EMployees those are Managers, Directors only\n " +
                    "Enter 9 to Print All EMployees Having Salary in Range 25000 to 75000\n" +
                    "Enter 10 to Print Employee with Second MAx Salary Per DeptName\n " +
                    "Enter 11 to Print Employee with Second Max Salary\n " +
                    "Enter 12 to  Calculate Tax for Each Employee as followa\n" +
                    "Enter  13 for join\n" +
                    "Enter 14 to exit");
                int Num = int.Parse(Console.ReadLine());
                switch (Num)
                {
                    case 1:
                        employee_Operation.EmployeeAscending(ref employee);
                        break;
                    case 2:
                        employee_Operation.DeptCount(ref employee);
                        break;
                    case 3:
                        employee_Operation.DeptWiseSumSalary(ref employee);

                        break;
                    case 4:
                        employee_Operation.DeptWiseMaxSalary(ref employee);
                        break;
                    case 5:
                        employee_Operation.DeptWiseMinSalary(ref employee);
                        break;
                    case 6:
                        employee_Operation.DeptWiseAvgSalary(ref employee);
                        break;
                    case 7:
                        employee_Operation.DesigWiseGroup(ref employee);
                        break;
                    case 8:
                        employee_Operation.DisplayEmployee(ref employee);
                        break;
                    case 9:
                        employee_Operation.SalaryRange(ref employee);
                        break;
                    case 10:
                        employee_Operation.secondMaxSalaryDeptWise(ref employee);
                        break;
                    case 11:
                        employee_Operation.SecondMaxSalary(ref employee);
                        break;
                    case 12:
                        employee_Operation._Tax(ref employee);
                        break;
                    case 13:
                        employee_Operation.Join(ref modifiedEmployee, ref departments);
                        break;

                    case 14:
                        exit++;
                        break;
                    default:
                        Console.WriteLine("Please select Valid Entry");
                        break;


                }

            } while (exit == 0);

        }
    }
}