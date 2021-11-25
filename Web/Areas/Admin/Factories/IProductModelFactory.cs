using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Areas.Admin.ViewModels.Products;

namespace Web.Areas.Admin.Factories
{
    public  interface IProductModelFactory
    {
        Task<ProductListModel> PrepareProductListModelAsync( int pageSize, int pageNumber);

        Task<ProductListModel> PrepareProductNODiscountListModelAsync(int pageSize, int pageNumber);
    }
}
