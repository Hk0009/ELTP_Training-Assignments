using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_7
{
    internal class Employee
    {
        public int EmpNo { get; set; }
        public string EmpName { get; set; }
        public string DeptName { get; set; }
        public int Salary { get; set; }


        public string Designation { get; set; }
    }
    internal class Employees : List<Employee>
    {
        public Employees()
        {
            Add(new Employee() { EmpNo = 101, EmpName = "Mahesh", DeptName = "IT", Salary = 11000, Designation = "Manager" });
            Add(new Employee() { EmpNo = 102, EmpName = "Tejas", DeptName = "HR", Salary = 12000, Designation = "Intern" });
            Add(new Employee() { EmpNo = 103, EmpName = "Nandu", DeptName = "SL", Salary = 13000, Designation = "Director" });
            Add(new Employee() { EmpNo = 104, EmpName = "Anil", DeptName = "IT", Salary = 14000, Designation = "Clerk" });
            Add(new Employee() { EmpNo = 105, EmpName = "Jaywant", DeptName = "HR", Salary = 10000, Designation = "Staff" });
            Add(new Employee() { EmpNo = 106, EmpName = "Abhay", DeptName = "SL", Salary = 9000, Designation = "Emgineer" });
            Add(new Employee() { EmpNo = 107, EmpName = "Anil", DeptName = "IT", Salary = 8000, Designation = "Manager" });
            Add(new Employee() { EmpNo = 108, EmpName = "Shyam", DeptName = "HR", Salary = 7000, Designation = "Engineer" });
            Add(new Employee() { EmpNo = 109, EmpName = "Vikram", DeptName = "SL", Salary = 6000, Designation = "Intern" });
            Add(new Employee() { EmpNo = 110, EmpName = "Suprotim1", DeptName = "IT", Salary = 5000, Designation = "Manager" });
            Add(new Employee() { EmpNo = 111, EmpName = "Mahesh1", DeptName = "IT", Salary = 21000, Designation = "Manager" });
            Add(new Employee() { EmpNo = 112, EmpName = "Tejas1", DeptName = "HR", Salary = 22000, Designation = "Intern" });
            Add(new Employee() { EmpNo = 113, EmpName = "Nandu1", DeptName = "SL", Salary = 23000, Designation = "Director" });
            Add(new Employee() { EmpNo = 114, EmpName = "Anil1", DeptName = "IT", Salary = 24000, Designation = "Clerk" });
            Add(new Employee() { EmpNo = 115, EmpName = "Jaywant1", DeptName = "HR", Salary = 20000, Designation = "Staff" });
            Add(new Employee() { EmpNo = 116, EmpName = "Abhay1", DeptName = "SL", Salary = 29000, Designation = "Emgineer" });
            Add(new Employee() { EmpNo = 117, EmpName = "Anil1", DeptName = "IT", Salary = 28000, Designation = "Manager" });
            Add(new Employee() { EmpNo = 118, EmpName = "Shyam1", DeptName = "HR", Salary = 27000, Designation = "Engineer" });
            Add(new Employee() { EmpNo = 119, EmpName = "Vikram1", DeptName = "SL", Salary = 26000, Designation = "Intern" });
            Add(new Employee() { EmpNo = 120, EmpName = "Suprotim1", DeptName = "IT", Salary = 25000, Designation = "Manager" });
            Add(new Employee() { EmpNo = 121, EmpName = "Mahesh2", DeptName = "IT", Salary = 31000, Designation = "Manager" });
            Add(new Employee() { EmpNo = 122, EmpName = "Tejas2", DeptName = "HR", Salary = 32000, Designation = "Intern" });
            Add(new Employee() { EmpNo = 123, EmpName = "Nandu2", DeptName = "SL", Salary = 33000, Designation = "Director" });
            Add(new Employee() { EmpNo = 124, EmpName = "Anil2", DeptName = "IT", Salary = 34000, Designation = "Clerk" });
            Add(new Employee() { EmpNo = 125, EmpName = "Jaywant2", DeptName = "HR", Salary = 40000, Designation = "Staff" });
            Add(new Employee() { EmpNo = 126, EmpName = "Abhay2", DeptName = "SL", Salary = 39000, Designation = "Emgineer" });
            Add(new Employee() { EmpNo = 127, EmpName = "Anil2", DeptName = "IT", Salary = 38000, Designation = "Manager" });
            Add(new Employee() { EmpNo = 128, EmpName = "Shyam2", DeptName = "HR", Salary = 37000, Designation = "Engineer" });
            Add(new Employee() { EmpNo = 129, EmpName = "Vikram2", DeptName = "SL", Salary = 36000, Designation = "Intern" });
            Add(new Employee() { EmpNo = 130, EmpName = "Suprotim2", DeptName = "IT", Salary = 35000, Designation = "Manager" });
            Add(new Employee() { EmpNo = 131, EmpName = "Mahesh3", DeptName = "IT", Salary = 41000, Designation = "Manager" });
            Add(new Employee() { EmpNo = 132, EmpName = "Tejas3", DeptName = "HR", Salary = 42000, Designation = "Intern" });
            Add(new Employee() { EmpNo = 133, EmpName = "Nandu3", DeptName = "SL", Salary = 43000, Designation = "Director" });
            Add(new Employee() { EmpNo = 134, EmpName = "Anil3", DeptName = "IT", Salary = 44000, Designation = "Clerk" });
            Add(new Employee() { EmpNo = 135, EmpName = "Jaywant3", DeptName = "HR", Salary = 40000, Designation = "Staff" });
            Add(new Employee() { EmpNo = 136, EmpName = "Abhay3", DeptName = "SL", Salary = 49000, Designation = "Emgineer" });
            Add(new Employee() { EmpNo = 137, EmpName = "Anil3", DeptName = "IT", Salary = 48000, Designation = "Manager" });
            Add(new Employee() { EmpNo = 138, EmpName = "Shyam3", DeptName = "HR", Salary = 47000, Designation = "Engineer" });
            Add(new Employee() { EmpNo = 139, EmpName = "Vikram3", DeptName = "SL", Salary = 46000, Designation = "Intern" });
            Add(new Employee() { EmpNo = 130, EmpName = "Suprotim3", DeptName = "IT", Salary = 45000, Designation = "Manager" });
            Add(new Employee() { EmpNo = 141, EmpName = "Mahesh4", DeptName = "IT", Salary = 51000, Designation = "Manager" });
            Add(new Employee() { EmpNo = 142, EmpName = "Tejas4", DeptName = "HR", Salary = 52000, Designation = "Intern" });
            Add(new Employee() { EmpNo = 143, EmpName = "Nandu4", DeptName = "SL", Salary = 53000, Designation = "Director" });
            Add(new Employee() { EmpNo = 144, EmpName = "Anil4", DeptName = "IT", Salary = 54000, Designation = "Clerk" });
            Add(new Employee() { EmpNo = 145, EmpName = "Jaywant4", DeptName = "HR", Salary = 60000, Designation = "Staff" });
            Add(new Employee() { EmpNo = 146, EmpName = "Abhay4", DeptName = "SL", Salary = 59000, Designation = "Emgineer" });
            Add(new Employee() { EmpNo = 147, EmpName = "Anil4", DeptName = "IT", Salary = 50000, Designation = "Manager" });
            Add(new Employee() { EmpNo = 148, EmpName = "Shyam4", DeptName = "HR", Salary = 57000, Designation = "Engineer" });
            Add(new Employee() { EmpNo = 149, EmpName = "Vikram4", DeptName = "SL", Salary = 66000, Designation = "Intern" });
            Add(new Employee() { EmpNo = 150, EmpName = "Suprotim4", DeptName = "IT", Salary = 55000, Designation = "Manager" });

        }
    }
}
