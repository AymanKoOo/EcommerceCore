using Core.Entites.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entites.Orders
{
    public class OrderItem : EntityBase
    {
        public int OrderId { get; set; }
        public Order order { get; set; }
     
        public int ProductId { get; set; }
        public Product product { get; set; }

        //Prices//
        public decimal UnitPriceInclTax { get; set; }
        public decimal UnitPriceExclTax { get; set; }
        public decimal PriceInclTax { get; set; }
        public decimal PriceExclTax { get; set; }
        public decimal DiscountAmountInclTax { get; set; }
        public decimal DiscountAmountExclTax { get; set; }
        public decimal OriginalProductCost { get; set; }
    }
}
