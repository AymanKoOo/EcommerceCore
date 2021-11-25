using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Areas.Admin.ViewModels.Products;

namespace Web.Areas.Admin.Factories
{
    public  interface IProductModelFactory
    {
        Task<ProductListModel> PrepareDiscountProductListModelAsync( int pageSize, int pageNumber);


    }
}
