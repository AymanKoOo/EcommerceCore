using Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Areas.Admin.ViewModels.Products;

namespace Web.ViewModels.Discounts
{
    public class DiscountsVM
    {
         public ProductListModel discountProductListModel { get; set; }
         public Discount discount { get; set; }
    }
}
