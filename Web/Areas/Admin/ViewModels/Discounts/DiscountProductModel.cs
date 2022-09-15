using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Areas.Admin.ViewModels.Discounts
{
    public class DiscountProductModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string picture { get; set; }
        public decimal OldPrice { get; set; }
        public decimal Price { get; set; }
        public bool HasDiscountsApplied { get; set; }
    }
}
