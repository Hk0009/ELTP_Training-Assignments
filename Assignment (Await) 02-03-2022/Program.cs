using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment__Await__02_03_2022.DataAccess;
using Assignment__Await__02_03_2022.Models;

namespace Assignment__Await__02_03_2022
{
    internal class Program
    {
        static void Main(string[] args)
        {

            IDataAccess<ComEmployee, int> emp = new CRUD();
            IDataAccess<Mydatabase,int> dept = new CrudDepartment();
           // IDataAccess2<ComEmployee, String> emp2 = new Report();
            //report1 rep1 = new report1();
            int a = 0;
            do
            {
                Console.WriteLine("Enter Operation that You want to perform \n" + "1.Add new record in employee\n" +
               "2.Get Data of employee \n" + " 3.Delete records of employee \n  " + "4.Updating records of employee\n"  + "5.Add new record in Department\n" +
               "6.Get Data of Department\n" + "7.Updating records of Department\n" + "8.Delete records of Department\n"

);
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
                       
                        break;
                    case 2:
                        var employees = emp.GetData().Result;


                        ComEmployee employeee = new ComEmployee();


                        foreach (var employee in employees)
                        {
                            Console.WriteLine($"{employee.EmpNo}   {employee.EmpName} {employee.Salary} {employee.Designation} {employee.DeptNo}  {employee.Email}");
                        }
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
                    case 3:
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
                    case 5:
                        //add department
                        Console.WriteLine("Enter department No");
                        int DepartemntNo = int.Parse(Console.ReadLine());

                        Console.WriteLine("Enter Department name");
                        string DeptName = Console.ReadLine();

                        Console.WriteLine("Enter capacity of the department");
                        int Capacity = int.Parse(Console.ReadLine());

                        Console.WriteLine("Enter location");
                        string Location = Console.ReadLine();

                        var newDept = new Mydatabase()
                        {
                            DeptNo = DepartemntNo,
                            DeptName = DeptName,
                            Capacty = Capacity,
                            Location = Location

                        };

                        var d = dept.Create(newDept);
                        break;


                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                    case 6:
                        var readDept = dept.GetData().Result;
                        foreach (var item in readDept)
                        {
                            Console.WriteLine($"{item.DeptNo} {item.DeptName} {item.Location} {item.Capacty} ");
                        }
                        break;
                    case 7:
                        Console.WriteLine("Enter department Number that is to be updated");
                        int uDeptNo = int.Parse(Console.ReadLine());

                        Console.WriteLine("Enter updated Department name");
                        string uDeptName = Console.ReadLine();

                        Console.WriteLine("Enter updated capacity of the department");
                        int pCapacty = int.Parse(Console.ReadLine());

                        Console.WriteLine("Enter updated location");
                        string uLocation = Console.ReadLine();

                        var updatedDept = new Mydatabase()
                        {
                            DeptNo = uDeptNo,
                            DeptName = uDeptName,
                            Capacty = pCapacty,
                            Location = uLocation

                        };

                        var e = dept.Update(uDeptNo,updatedDept);
                        break;

                    case 8:
                        Console.WriteLine("Enter Department number that is to be Deleted");
                        int Delete_Deptid = int.Parse(Console.ReadLine());
                        var deletedDeptInfo = dept.Delete(Delete_Deptid);
                        if (deletedDeptInfo == null)
                        {
                            Console.WriteLine("couldn't delete Department");
                        }
                        else
                        {
                            Console.WriteLine("Department deleted sucessfully");
                        }
                        break;


                }
            } while (a == 0);
            Console.ReadLine();

        }
    }
}
