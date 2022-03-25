using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud.Models
{
    internal class EmployeeDepartment
    {
        public int EmpNo { get; set; }
        public string EmpName { get; set; }
        public int Salary { get; set; }
       public string Designation { get; set; }
        public int DeptNo { get; set; }
        public string Email { get; set; }
      
        public string DeptName { get; set; }
        public string Location { get; set; }
        public int Capacty { get; set; }
    }
}
