using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entites
{
    public class DiscountCategory
    {
        public int DiscountsId { get; set; }
        public Discount discounts { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
