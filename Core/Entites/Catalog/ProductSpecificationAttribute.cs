using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entites.Catalog
{
    public class ProductSpecificationAttribute
    {
        public int ProductId { get; set; }
        public Product product { get; set; }

        public int SpecificationAttributeOptionId { get; set; }
        public SpecificationAttributeOption specificationAttributeOption { get; set; }
    }
}
