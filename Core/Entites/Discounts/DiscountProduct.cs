using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entites
{
    public class DiscountProduct
    {
        public int DiscountsId { get; set; }
        public Discount discounts { get; set; }

        public int ProductsId { get; set; }
        public Product products { get; set; }
    }
}
