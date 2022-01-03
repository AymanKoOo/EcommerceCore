using Core.Entites;
using Core.Entites.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Areas.Admin.ViewModels.Catalog
{
    public class AProductAttributeOptionModel
    {
        public string Name { get; set; }
        public int DisplayOrder { get; set; }
        public int ProductAttributeId { get; set; }
        public decimal PriceAdjustment { get; set; }
        public decimal WeightAdjustment { get; set; }
        public IEnumerable<ProductAttribute> productAttributes { get; set; }
        public ProductAttribute productAttribute { get; set; }
    }
}
