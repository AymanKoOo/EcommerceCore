using Core.Entites;
using Core.Entites.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.ViewModels.Products;

namespace Web.ViewModels.ShoppCart
{
    public class ProductsInCart
    {
        public int Qty { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Picture { get; set; }
        public List<ProductAttributeMappingVM> productAttributeOptionsMapping { get; set; }
    }
}
