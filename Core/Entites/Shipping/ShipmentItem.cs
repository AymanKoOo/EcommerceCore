using Core.Entites.Base;
using Core.Entites.Orders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entites.Shipping
{
    public class ShipmentItem : EntityBase
    {
        public int ShipmentId { get; set; }
        public Shipment shipment { get; set; }
        public int OrderItem { get; set; }
        public OrderItem orderItem { get; set; }
    }
}
