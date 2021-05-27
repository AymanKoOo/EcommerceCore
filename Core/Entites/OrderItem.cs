using System;
using System.Collections.Generic;
using System.Text;
using Core.Entites.Base;

namespace Core.Entites
{
    public class OrderItem : EntityBase
    {
        public int Quantity { get; set; }
        public string Color { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }

    }
}
