using System;
using System.Collections.Generic;

namespace Assignment_07_03_2022.Models
{
    public partial class DeptEmp
    {
        public string DeptName { get; set; } = null!;
        public string Location { get; set; } = null!;
        public int EmpNo { get; set; }
        public string EmpName { get; set; } = null!;
        public int Salary { get; set; }
        public string Designation { get; set; } = null!;
    }
}
