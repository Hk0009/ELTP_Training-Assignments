using System;
using System.Collections.Generic;

namespace StoredProcEFCore.Models
{
    public partial class ProductMaster
    {
        public int Id { get; set; }
        public string ProductId { get; set; } = null!;
        public string ProductName { get; set; } = null!;
        public string CategoryName { get; set; } = null!;
        public int Price { get; set; }
    }
}
