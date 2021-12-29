using Core.Entites;
using Core.Entites.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Areas.Admin.ViewModels.Catalog;
using Web.Areas.Admin.ViewModels.Products;

namespace Web.Areas.Admin.Factories
{
    public  interface IProductModelFactory
    {
        Task<ProductListModel> PrepareProductListModelAsync( int pageSize, int pageNumber);
        Task<ProductListModel> PrepareProductNODiscountListModelAsync(int pageSize, int pageNumber);
        Task<AProductModel> PrepareProductModelAsync(AProductModel model, Product product);
        Task<ProductListModel> PrepareProductByCategoryListModelAsync(int categoryID, int pageSize, int pageNumber,List<SpecificationAttributeOption> specificationAttributeOption,int OrderFilter);
        Task<AProductSpecificationOption> PrepareProductSpecifcationAttr();
    }
}
