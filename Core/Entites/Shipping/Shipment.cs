using Core.Entites.Base;
using Core.Entites.Orders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entites.Shipping
{
    public class Shipment:EntityBase
    {
        public int OrderId { get; set; }
        public Order order { get; set; }

        public decimal? TotalWeight { get; set; }
        public DateTime? ShippedDateUtc { get; set; }
        public DateTime? DeliveryDateUtc { get; set; }
        public DateTime CreatedOnUtc { get; set; }
    }
}
