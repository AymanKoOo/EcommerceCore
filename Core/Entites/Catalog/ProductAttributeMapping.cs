using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entites.Catalog
{
    public class ProductAttributeMapping
    {
        public int ProductId { get; set; }
        public Product product { get; set; }

        public int ProductAttributeOptionId { get; set; }
        public ProductAttributeOption productAttributeOption { get; set; }
    }
}
