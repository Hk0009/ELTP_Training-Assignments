using System;
using System.Collections.Generic;

namespace RestaurantBilling.Models
{
    public partial class Order
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public int DishId { get; set; }
        public int? Quantity { get; set; }
        public int? Toatal { get; set; }

        public virtual Customerinfo Customer { get; set; } = null!;
        public virtual DishInfo Dish { get; set; } = null!;
    }
}
