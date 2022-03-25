using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_7
{
    internal class Department
    {
        public int DeptNo { get; set; }
        public string DeptName { get; set; }
        public string Location { get; set; }
        public int Capacity { get; set; }
    }
    internal class Departments : List<Department>
    {
        public Departments()
        {
            Add(new Department() { DeptNo = 1, DeptName = "IT", Location = "Pune", Capacity = 100 });
            Add(new Department() { DeptNo = 2, DeptName = "HR", Location = "Noida", Capacity = 100 });
            Add(new Department() { DeptNo = 3, DeptName = "SL", Location = "Nagpur", Capacity = 100 });
            Add(new Department() { DeptNo = 4, DeptName = "IT", Location = "Delhi", Capacity = 100 });
            Add(new Department() { DeptNo = 5, DeptName = "HR", Location = "Mumbai", Capacity = 100 });
            Add(new Department() { DeptNo = 6, DeptName = "SL", Location = "Goa", Capacity = 100 });
            Add(new Department() { DeptNo = 7, DeptName = "IT", Location = "Banglaore", Capacity = 100 });
            Add(new Department() { DeptNo = 8, DeptName = "HR", Location = "Nasik", Capacity = 100 });
            Add(new Department() { DeptNo = 9, DeptName = "SL", Location = "Pimpri", Capacity = 100 });
            Add(new Department() { DeptNo = 10, DeptName = "IT", Location = "Gurgaon", Capacity = 100 });
        }

    }
}
