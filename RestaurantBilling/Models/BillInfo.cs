using System;
using System.Collections.Generic;

namespace RestaurantBilling.Models
{
    public partial class BillInfo
    {
        public int BillNo { get; set; }
        public int CustomerId { get; set; }
        public int DishId { get; set; }
        public int Total { get; set; }

        public virtual Customerinfo Customer { get; set; } = null!;
        public virtual DishInfo Dish { get; set; } = null!;
    }
}
