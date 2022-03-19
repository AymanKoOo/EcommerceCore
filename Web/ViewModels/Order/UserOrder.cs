using Core.Entites.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.ViewModels.Order
{
    public class UserOrder
    {
        public int orderTag { get; set; }
        public DateTime orderDate { get; set; }
        public string ShippingMethod { get; set; }
        public string shippingAdrees { get; set; }
        public decimal orderTotal { get; set; }
        public string CustomerName { get; set; }

        public OrderItem orderItems { get; set; }
        public DateTime ShippedDateUtc { get; set; }
        public DateTime DeliveryDateUtc { get; set; }
    }
}
