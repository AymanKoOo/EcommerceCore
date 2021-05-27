using System;
using System.Collections.Generic;
using System.Text;
using Core.Entites.Base;

namespace Core.Entites
{
    public class Order : EntityBase
    {
        public string UserName { get; set; }
        //public Address BillingAddress { get; set; }
        //public Address ShippingAddress { get; set; }
       // public PaymentMethod PaymentMethod { get; set; }
        //public OrderStatus Status { get; set; }
        public decimal GrandTotal { get; set; }

        public List<OrderItem> Items { get; set; } = new List<OrderItem>();
    }
}
