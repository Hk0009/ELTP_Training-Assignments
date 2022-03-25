using Ef_CoreDbfirst.Models;
using Ef_CoreDbfirst.DataAccess;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

// See https://aka.ms/new-console-template for more information



int a = 0;
do
{
    IDataAccess<Mydatabase, int> deptdb = new DepartmentDataAccess();
    IDataAccess<ComEmployee, int> empdb = new EmployeeDataAccess();

    Console.WriteLine("1. Enter 1 to get data of Department\n" +
        "2. Enter 2 to insert data into Department\n" +
        "3. Enter 3 to Update specific data in Department\n" +
        "4. Enter 4 to Delete data from Department\n" +
        "5. Enter 5 to get data of Department\n" +
        "6. Enter 6 to insert data into Department\n" +
        "7. Enter 7 to Update specific data in Department\n" +
        "8. Enter 8 to Delete data from Department\n");
    int Input = Convert.ToInt32(Console.ReadLine());
    switch (Input)
    {
        case 1:
            var deptGetData = await deptdb.GetAsync();
            Console.WriteLine($"List of Depts" +
    $"{JsonSerializer.Serialize(deptGetData)}");

            break;
        case 2:
            //Mydatabase mydatabase = new Mydatabase();
            Console.WriteLine("Enter Dept name");
            string? DeptName = Console.ReadLine();
            Console.WriteLine("Enter Dept Number");
            int DeptNo = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Capacity");
            int Capctay = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Location ");
            string? Location = Console.ReadLine();
            Mydatabase db = new()
            {
                DeptName = DeptName,
                DeptNo = DeptNo,
                Capctay = Capctay,
                Location = Location
            };
            var insertDept = await deptdb.CreateAsync(db);
            if (insertDept == null)
            {
                Console.WriteLine("Fail");
            }
            else
            {
                Console.WriteLine("Data Added sucessfully");
            }
            break;
        case 4:
            Console.WriteLine("Enter DeptNo you want to Delete");
            int input = Convert.ToInt32(Console.ReadLine());
            var DeleteDept = await deptdb.DeleteAsync(input);
            Console.WriteLine($"Deleted Dept" +
    $"{JsonSerializer.Serialize(DeleteDept)}");
            break;
        case 3:
            Console.WriteLine("Enter Dept name");
            string? UpdatedName = Console.ReadLine();
            Console.WriteLine("Enter Dept Number");
            int UpdatedDeptNo = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Capacity");
            int UpdatedCapctay = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Location ");
            string? UpdatedLocation = Console.ReadLine();
            Mydatabase updatedb = new()
            {
                DeptName = UpdatedName,
                DeptNo = UpdatedDeptNo,
                Capctay = UpdatedCapctay,
                Location = UpdatedLocation
            };
            var updated = await deptdb.UpdateAsync(updatedb, UpdatedDeptNo);
            Console.WriteLine($"Updated Dept" +
    $"{JsonSerializer.Serialize(updatedb)}");
            break;
        case 5:
            var EmpGetData = await empdb.GetAsync();
            Console.WriteLine($"List of Depts" +
    $"{JsonSerializer.Serialize(EmpGetData)}");

            break;
        case 6:
            Console.WriteLine("Enter Employee name");
            string? EmpName = Console.ReadLine();
            Console.WriteLine("Enter Employee Number");
            int EmpNo = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Employee Designation");
            string? Designation = Console.ReadLine();
            Console.WriteLine("Enter Employee Dept No");
            int DeptNo1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Employee Email ");
            string? Email = Console.ReadLine();
            Console.WriteLine("Enter Employee Salary ");
            int Salary = Convert.ToInt32(Console.ReadLine());
            ComEmployee employeedb = new()
            {
                EmpName = EmpName,
                EmpNo = EmpNo,
                Designation = Designation,
                Salary = Salary,
                Email = Email,
                DeptNo = DeptNo1

            };
            var insertEmp = await empdb.CreateAsync(employeedb);
            if (insertEmp == null)
            {
                Console.WriteLine("Fail");
            }
            else
            {
                Console.WriteLine("Data Added sucessfully");
            }
            break;
        case 8:
            Console.WriteLine("Enter DeptNo you want to Delete");
            int empno = Convert.ToInt32(Console.ReadLine());
            var DeleteEmp = await deptdb.DeleteAsync(empno);
            Console.WriteLine($"Deleted Employee" +
    $"{JsonSerializer.Serialize(DeleteEmp)}");

            break;
        case 7:
            Console.WriteLine("Enter Employee name");
            string? UpdateEmpName = Console.ReadLine();
            Console.WriteLine("Enter Employee Number");
            int UpdateEmpNo = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter employee Designation");
            string? UpdateDesignation = Console.ReadLine();
            Console.WriteLine("Enter employee Dept No");
            int UpdateDeptNo1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Employee EMail ");
            string? UpdateEmail = Console.ReadLine();
            Console.WriteLine("Enter Employee Salary ");
            int UpdateSalary = Convert.ToInt32(Console.ReadLine());
            ComEmployee employeedb1 = new()
            {
                EmpName = UpdateEmpName,
                EmpNo = UpdateEmpNo,
                Designation = UpdateDesignation,
                Salary = UpdateSalary,
                Email = UpdateEmail,
                DeptNo = UpdateDeptNo1

            };
            var updated2 = await empdb.UpdateAsync(employeedb1, UpdateEmpNo);
            Console.WriteLine($"Updated Dept" +
    $"{JsonSerializer.Serialize(updated2)}");
            break;






    }



} while (a == 0);