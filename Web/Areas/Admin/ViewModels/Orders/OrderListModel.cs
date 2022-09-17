using Core.Entites.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.DTOs;

namespace Web.Areas.Admin.ViewModels.Products
{
    public class ProductListModel: BasePagedListModel<ProductModel>
    {
      public List<SpecificationAttribute> SpecificationAttributes { get; set; }
    }
}
