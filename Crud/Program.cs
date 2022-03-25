using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Crud.Models;
using Crud.DataAccess;

namespace Crud
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            IDataAccess<ComEmployee,int> emp = new CRUD();
            IDataAccess2<ComEmployee, String> emp2 = new Report();
            int a = 0;
            do
            {
                Console.WriteLine("Enter Operation that You want to perform \n" + "1.Add new record\n" +
               "2.Get Data \n" + "3.Print data on EmpNo\n" + "4.Updating records \n" + "5.Delete Records\n"
               + "6.Exit Program");
                Console.WriteLine("-------------------------------------------------------------------------------------------");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Add new Record");
                        var empNew1 = new ComEmployee();
                        Console.WriteLine("enter EmpNO");
                        empNew1.EmpNo = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("enter EmpName");
                        empNew1.EmpName = Console.ReadLine();
                        Console.WriteLine("enter Salary");
                        empNew1.Salary = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("enter Designation");
                        empNew1.Designation = Console.ReadLine();
                        Console.WriteLine("enter DeptNo");
                        empNew1.DeptNo = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("enter Email");
                        empNew1.Email = Console.ReadLine();
                        var result1 = emp.Create(empNew1);
                        if (result1 == null)
                        {
                            Console.WriteLine("Faild...........");
                        }
                        else
                        {
                            Console.WriteLine("Data Added Successfully.......");
                        }
                        Console.WriteLine("-------------------------------------------------------------------------------------------");
                        break;
                    case 2:
                        var employees = emp.GetData();


                        //ComEmployee employeee = new ComEmployee();


                        foreach(var employee in employees)
                        {
                            Console.WriteLine($"{employee.EmpNo}   {employee.EmpName} {employee.Salary} {employee.Designation} {employee.DeptNo}  {employee.Email}");
                        }
                        Console.WriteLine("-------------------------------------------------------------------------------------------");
                        break;
                    case 3:
                        Console.WriteLine("Print Record based on the EmpNo ");
                        Console.WriteLine("Enter EmpNo");
                        var emp1 = emp.GetData(Convert.ToInt32(Console.ReadLine()));
                        Console.WriteLine("EmpNo EmpName  salary  Designation  DeptNo Email");
                        Console.WriteLine($"{emp1.EmpNo}  {emp1.EmpName} {emp1.Salary} {emp1.Designation} {emp1.DeptNo}  {emp1.Email}");
                        Console.WriteLine("-------------------------------------------------------------------------------------------");
                        break;
                    case 4:
                        Console.WriteLine("Updating new Record");
                        //Console.WriteLine("Enter EmpNo\n"+"Enter EmpName\n"+"Enter salary\n" + "Enter Designatioin\n" + "Enter DeptNo\n" +"Enter Email\n");
                        var empNew = new ComEmployee();
                        Console.WriteLine("enter EmpNO");
                        empNew.EmpNo = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("enter EmpName");
                        empNew.EmpName = Console.ReadLine();
                        Console.WriteLine("enter Salary");
                        empNew.Salary = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("enter Designation");
                        empNew.Designation = Console.ReadLine();
                        Console.WriteLine("enter DeptNo");
                        empNew.DeptNo = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("enter Email");
                        empNew.Email = Console.ReadLine();
                        // Console.WriteLine(" Enter EmpNo on which you are performing Update operation");
                        // int EmpNo = Convert.ToInt32(Console.ReadLine());
                        var result = emp.Update(empNew.EmpNo, empNew);
                        if (result == null)
                        {
                            Console.WriteLine("Upate Faild");
                        }
                        else
                        {
                            Console.WriteLine("Update Success");
                        }
                       
                        break;
                    case 5:
                        Console.WriteLine("Call for delete");
                        Console.WriteLine("Enter EmpNo");
                        int EmpNo1 = Convert.ToInt32(Console.ReadLine());
                        var resDelete = emp.Delete(EmpNo1);
                        if (resDelete == null)
                        {
                            Console.WriteLine("No record found");
                        }
                        else
                        {
                            Console.WriteLine("Record deleted");
                        }
                        //Console.WriteLine("Data After Deleting the record");
                        //var emp2 = empdata.GetData(EmpNo1);
                        //Console.WriteLine($"{emp2.EmpNo}  {emp2.EmpName} {emp2.salary} {emp2.Designation} {emp2.DeptNo}  {emp2.Email}");
                       
                        break;
                    case 6:
                        a++;
                        break;
                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                    case 7:
                        Console.WriteLine("GetData");
                        string data= Console.ReadLine();
                        emp2.GetSumSalaryByDeptName(data);
                        break;
                }
            } while (a == 0);
            Console.ReadLine();

        }
    }
}
