using System;
using System.Collections.Generic;

namespace RestaurantBilling.Models
{
    public partial class Customerinfo
    {
        public Customerinfo()
        {
            BillInfos = new HashSet<BillInfo>();
            Orders = new HashSet<Order>();
        }

        public int CustomerId { get; set; }
        public string CustomerName { get; set; } = null!;
        public string? CustomerMobile { get; set; }

        public virtual ICollection<BillInfo> BillInfos { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
