using System;
using System.Collections.Generic;

namespace RestaurantBilling.Models
{
    public partial class DishInfo
    {
        public DishInfo()
        {
            BillInfos = new HashSet<BillInfo>();
            Orders = new HashSet<Order>();
        }

        public int DishId { get; set; }
        public string DishName { get; set; } = null!;
        public int? Price { get; set; }

        public virtual ICollection<BillInfo> BillInfos { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
