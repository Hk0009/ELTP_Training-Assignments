using System;
using System.Collections.Generic;

namespace Assignment_07_03_2022.Models
{
    public partial class ComEmployee
    {
        public int EmpNo { get; set; }
        public string EmpName { get; set; } = null!;
        public int Salary { get; set; }
        public string Designation { get; set; } = null!;
        public int DeptNo { get; set; }
        public string Email { get; set; } = null!;

        public virtual Mydatabase DeptNoNavigation { get; set; } = null!;
    }
}
