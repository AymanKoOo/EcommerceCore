using Core.Entites.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Areas.Admin.ViewModels.Orders
{
    public class OrderDetail
    {
        public Order order { get; set; }
        public IEnumerable<OrderItem> orderItem { get; set; }
    }
}
