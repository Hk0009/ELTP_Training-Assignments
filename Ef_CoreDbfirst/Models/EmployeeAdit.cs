using System;
using System.Collections.Generic;

namespace Ef_CoreDbfirst.Models
{
    public partial class EmployeeAdit
    {
        public int Auditid { get; set; }
        public int AuditEmpNo { get; set; }
        public DateTime AuditDate { get; set; }
    }
}
