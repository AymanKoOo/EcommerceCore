using System;
using System.Collections.Generic;
using System.Text;
using Core.Entites.Base;

namespace Core.Entites
{
    public class CartItem : EntityBase
    {
        public int Quantity { get; set; }
        public string Color { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }

        //1-1
        public int ProductId { get; set; }
        public Product Product { get; set; }

    }
}
