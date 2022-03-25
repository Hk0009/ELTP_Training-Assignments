using System;
using System.Collections.Generic;

namespace StoredProcEFCore.Models
{
    public partial class Person
    {
        public int Id { get; set; }
        public string PersonId { get; set; } = null!;
        public string PersonName { get; set; } = null!;
        public string ResidenceNo { get; set; } = null!;
        public string ResidenceName { get; set; } = null!;
        public string Street { get; set; } = null!;
        public string City { get; set; } = null!;
    }
}
