using Core.Entites.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entites.Catalog
{
    public class ProductAttributeMapping:EntityBase
    {
        public int ProductId { get; set; }
        public Product product { get; set; }

        public int ProductAttributeId { get; set; }
        public ProductAttribute productAttribute { get; set; }

        public ICollection<ProductAttributeOption> productAttributeOptions { get; set; }
    }   
}
