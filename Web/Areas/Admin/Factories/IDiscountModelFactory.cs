using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Areas.Admin.ViewModels.Discounts;

namespace Web.Areas.Admin.Factories
{
    public interface IDiscountModelFactory
    {
        Task<DiscountProductListModel> PrepareDiscountProductListModelAsync(int discountid, int pageSize, int pageNumber);
        Task<DiscountCategoryListModel> PrepareDiscountCategoryListModelAsync(int discountid, int pageSize, int pageNumber);

    }
}
