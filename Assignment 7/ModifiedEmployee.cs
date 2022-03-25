using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_7
{
    internal class ModifiedEmployee
    {
        public int EmpNo { get; set; }
        public string EmpName { get; set; }
        public string DeptName { get; set; }
        public int Salary { get; set; }
        public int DeptNo { get; set; }

        public string Designation { get; set; }
    }
    internal class ModifiedEmployees : List<ModifiedEmployee>
    {
        public ModifiedEmployees()
        {
            Add(new ModifiedEmployee() { EmpNo = 101, EmpName = "Mahesh", DeptName = "IT", Salary = 11000, Designation = "Manager",DeptNo=50 });
            Add(new ModifiedEmployee() { EmpNo = 102, EmpName = "Tejas", DeptName = "HR", Salary = 12000, Designation = "Intern", DeptNo = 2 });
            Add(new ModifiedEmployee() { EmpNo = 103, EmpName = "Nandu", DeptName = "SL", Salary = 13000, Designation = "Director", DeptNo = 3 });
            Add(new ModifiedEmployee() { EmpNo = 104, EmpName = "Anil", DeptName = "IT", Salary = 14000, Designation = "Clerk", DeptNo = 4 });
            Add(new ModifiedEmployee() { EmpNo = 105, EmpName = "Jaywant", DeptName = "HR", Salary = 10000, Designation = "Staff", DeptNo = 5 });
            Add(new ModifiedEmployee() { EmpNo = 106, EmpName = "Abhay", DeptName = "SL", Salary = 9000, Designation = "Emgineer", DeptNo = 6 });
            Add(new ModifiedEmployee() { EmpNo = 107, EmpName = "Anil", DeptName = "IT", Salary = 8000, Designation = "Manager" , DeptNo = 7 });
            Add(new ModifiedEmployee() { EmpNo = 108, EmpName = "Shyam", DeptName = "HR", Salary = 7000, Designation = "Engineer", DeptNo = 8 });
            Add(new ModifiedEmployee() { EmpNo = 109, EmpName = "Vikram", DeptName = "SL", Salary = 6000, Designation = "Intern", DeptNo = 9 });
            Add(new ModifiedEmployee() { EmpNo = 110, EmpName = "Suprotim1", DeptName = "IT", Salary = 5000, Designation = "Manager" , DeptNo = 10 });
            Add(new ModifiedEmployee() { EmpNo = 111, EmpName = "Mahesh1", DeptName = "IT", Salary = 21000, Designation = "Manager", DeptNo = 11 });
            Add(new ModifiedEmployee() { EmpNo = 112, EmpName = "Tejas1", DeptName = "HR", Salary = 22000, Designation = "Intern", DeptNo = 12 });
            Add(new ModifiedEmployee() { EmpNo = 113, EmpName = "Nandu1", DeptName = "SL", Salary = 23000, Designation = "Director",DeptNo = 13 });
            Add(new ModifiedEmployee() { EmpNo = 114, EmpName = "Anil1", DeptName = "IT", Salary = 24000, Designation = "Clerk", DeptNo = 14 });
            Add(new ModifiedEmployee() { EmpNo = 115, EmpName = "Jaywant1", DeptName = "HR", Salary = 20000, Designation = "Staff", DeptNo = 15 });
            Add(new ModifiedEmployee() { EmpNo = 116, EmpName = "Abhay1", DeptName = "SL", Salary = 29000, Designation = "Emgineer", DeptNo = 16 });
            Add(new ModifiedEmployee() { EmpNo = 117, EmpName = "Anil1", DeptName = "IT", Salary = 28000, Designation = "Manager", DeptNo = 17 });
            Add(new ModifiedEmployee() { EmpNo = 118, EmpName = "Shyam1", DeptName = "HR", Salary = 27000, Designation = "Engineer", DeptNo = 18 });
            Add(new ModifiedEmployee() { EmpNo = 119, EmpName = "Vikram1", DeptName = "SL", Salary = 26000, Designation = "Intern", DeptNo = 19 });
            Add(new ModifiedEmployee() { EmpNo = 120, EmpName = "Suprotim1", DeptName = "IT", Salary = 25000, Designation = "Manager", DeptNo = 20 });
            Add(new ModifiedEmployee() { EmpNo = 121, EmpName = "Mahesh2", DeptName = "IT", Salary = 31000, Designation = "Manager", DeptNo = 21 });
            Add(new ModifiedEmployee() { EmpNo = 122, EmpName = "Tejas2", DeptName = "HR", Salary = 32000, Designation = "Intern" , DeptNo = 22 });
            Add(new ModifiedEmployee() { EmpNo = 123, EmpName = "Nandu2", DeptName = "SL", Salary = 33000, Designation = "Director", DeptNo = 23 });
            Add(new ModifiedEmployee() { EmpNo = 124, EmpName = "Anil2", DeptName = "IT", Salary = 34000, Designation = "Clerk", DeptNo = 24 });
            Add(new ModifiedEmployee() { EmpNo = 125, EmpName = "Jaywant2", DeptName = "HR", Salary = 40000, Designation = "Staff", DeptNo = 25 });
            Add(new ModifiedEmployee() { EmpNo = 126, EmpName = "Abhay2", DeptName = "SL", Salary = 39000, Designation = "Emgineer", DeptNo = 26 });
            Add(new ModifiedEmployee() { EmpNo = 127, EmpName = "Anil2", DeptName = "IT", Salary = 38000, Designation = "Manager", DeptNo = 27 });
            Add(new ModifiedEmployee() { EmpNo = 128, EmpName = "Shyam2", DeptName = "HR", Salary = 37000, Designation = "Engineer", DeptNo = 28 });
            Add(new ModifiedEmployee() { EmpNo = 129, EmpName = "Vikram2", DeptName = "SL", Salary = 36000, Designation = "Intern" , DeptNo = 29});
            Add(new ModifiedEmployee() { EmpNo = 130, EmpName = "Suprotim2", DeptName = "IT", Salary = 35000, Designation = "Manager", DeptNo = 30 });
            Add(new ModifiedEmployee() { EmpNo = 131, EmpName = "Mahesh3", DeptName = "IT", Salary = 41000, Designation = "Manager", DeptNo = 31 });
            Add(new ModifiedEmployee() { EmpNo = 132, EmpName = "Tejas3", DeptName = "HR", Salary = 42000, Designation = "Intern" , DeptNo = 32 });
            Add(new ModifiedEmployee() { EmpNo = 133, EmpName = "Nandu3", DeptName = "SL", Salary = 43000, Designation = "Director", DeptNo = 33 });
            Add(new ModifiedEmployee() { EmpNo = 134, EmpName = "Anil3", DeptName = "IT", Salary = 44000, Designation = "Clerk", DeptNo = 34 });
            Add(new ModifiedEmployee() { EmpNo = 135, EmpName = "Jaywant3", DeptName = "HR", Salary = 40000, Designation = "Staff", DeptNo = 35 });
            Add(new ModifiedEmployee() { EmpNo = 136, EmpName = "Abhay3", DeptName = "SL", Salary = 49000, Designation = "Emgineer", DeptNo = 36 });
            Add(new ModifiedEmployee() { EmpNo = 137, EmpName = "Anil3", DeptName = "IT", Salary = 48000, Designation = "Manager" , DeptNo = 37});
            Add(new ModifiedEmployee() { EmpNo = 138, EmpName = "Shyam3", DeptName = "HR", Salary = 47000, Designation = "Engineer", DeptNo = 38 });
            Add(new ModifiedEmployee() { EmpNo = 139, EmpName = "Vikram3", DeptName = "SL", Salary = 46000, Designation = "Intern", DeptNo = 39 });
            Add(new ModifiedEmployee() { EmpNo = 130, EmpName = "Suprotim3", DeptName = "IT", Salary = 45000, Designation = "Manager",DeptNo = 40 });
            Add(new ModifiedEmployee() { EmpNo = 141, EmpName = "Mahesh4", DeptName = "IT", Salary = 51000, Designation = "Manager" , DeptNo = 41});
            Add(new ModifiedEmployee() { EmpNo = 142, EmpName = "Tejas4", DeptName = "HR", Salary = 52000, Designation = "Intern", DeptNo = 42 });
            Add(new ModifiedEmployee() { EmpNo = 143, EmpName = "Nandu4", DeptName = "SL", Salary = 53000, Designation = "Director" , DeptNo = 44 });
            Add(new ModifiedEmployee() { EmpNo = 144, EmpName = "Anil4", DeptName = "IT", Salary = 54000, Designation = "Clerk" , DeptNo = 45 });
            Add(new ModifiedEmployee() { EmpNo = 145, EmpName = "Jaywant4", DeptName = "HR", Salary = 60000, Designation = "Staff" , DeptNo = 46 });
            Add(new ModifiedEmployee() { EmpNo = 146, EmpName = "Abhay4", DeptName = "SL", Salary = 59000, Designation = "Emgineer", DeptNo = 47 });
            Add(new ModifiedEmployee() { EmpNo = 147, EmpName = "Anil4", DeptName = "IT", Salary = 50000, Designation = "Manager", DeptNo = 48 });
            Add(new ModifiedEmployee() { EmpNo = 148, EmpName = "Shyam4", DeptName = "HR", Salary = 57000, Designation = "Engineer" , DeptNo = 49});
            Add(new ModifiedEmployee() { EmpNo = 149, EmpName = "Vikram4", DeptName = "SL", Salary = 66000, Designation = "Intern", DeptNo = 1 });
            Add(new ModifiedEmployee() { EmpNo = 150, EmpName = "Suprotim4", DeptName = "IT", Salary = 55000, Designation = "Manager" });

        }

    }
}
