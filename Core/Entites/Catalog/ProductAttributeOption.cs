using Core.Entites.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entites.Catalog
{
    public class ProductAttributeOption: EntityBase
    {

        public string Name { get; set; }
        public int DisplayOrder { get; set; }
        public string ColorSquaresRgb { get; set; }
        //Price//
        public decimal PriceAdjustment { get; set; }
        public decimal WeightAdjustment { get; set; }
        public ProductAttribute productAttribute { get; set; }

        public virtual ICollection<ProductAttributeMapping> ProductAttributeMappings { get; set; }

    }
}
