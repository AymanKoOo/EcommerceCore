using Core.Entites.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.ViewModels.Product
{
    public class ProductDeatilsVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal OldPrice { get; set; }
        public decimal Price { get; set; }
        public List<string> productPictures { get; set; }
        public bool HasDiscountsApplied { get; set; }
        public  ICollection<ProductAttributeMapping> ProductAttributeMappings { get; set; }

        public List<ProductAttribute> productAttributes { get; set; }

    }
}
