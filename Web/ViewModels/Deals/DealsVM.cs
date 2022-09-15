using Core.Entites.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Areas.Admin.ViewModels;
using Web.Areas.Admin.ViewModels.Discounts;

namespace Web.ViewModels.Deals
{
    public class DealsVM : BaseEntityModel
    {
         public  DiscountProductListModel discountProductListModel { get; set; }
         public  Deal deal { get; set; }
    }
}
