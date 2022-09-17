using Core.Entites.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Areas.Admin.ViewModels.Discounts;
using Web.Areas.Admin.ViewModels.Products;

namespace Web.Areas.Admin.Factories
{
    public interface IDiscountModelFactory
    {
        Task<ProductListModel> PrepareDiscountProductListModelAsync(int discountid, int pageSize, int pageNumber, int OrderFilter = 0, List<SpecificationAttributeOption> filterSpec = null);
        Task<DiscountCategoryListModel> PrepareDiscountCategoryListModelAsync(int discountid, int pageSize, int pageNumber);
        Task<ProductListModel> PrepareDiscountSProductListModelAsync(List<int> discountid,  int pageSize, int pageNumber, int OrderFilter = 0, List<SpecificationAttributeOption> filterSpec = null);
    }
}
