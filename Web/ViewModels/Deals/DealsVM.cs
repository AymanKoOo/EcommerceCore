using Core.Entites.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Areas.Admin.ViewModels;
using Web.Areas.Admin.ViewModels.Discounts;
using Web.Areas.Admin.ViewModels.Products;

namespace Web.ViewModels.Deals
{
    public class DealsVM : BaseEntityModel
    {
         public ProductListModel discountProductListModel { get; set; }
         public  Deal deal { get; set; }
    }
}
