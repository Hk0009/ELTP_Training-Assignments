using System;
using System.Collections.Generic;

namespace Assignment_07_03_2022.Models
{
    public partial class Mydatabase
    {
        public Mydatabase()
        {
            ComEmployees = new HashSet<ComEmployee>();
        }

        public int DeptNo { get; set; }
        public string DeptName { get; set; } = null!;
        public string Location { get; set; } = null!;
        public int Capctay { get; set; }

        public virtual ICollection<ComEmployee> ComEmployees { get; set; }
    }
}
