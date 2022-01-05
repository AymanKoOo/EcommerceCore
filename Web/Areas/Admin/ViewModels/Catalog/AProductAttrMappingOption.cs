using Core.Entites.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Areas.Admin.ViewModels.Catalog
{
    public class AProductAttrMappingOption
    {
        public ProductAttributeMapping mapped { get; set; }

        public string PicturePath { get; set; }
        public int DisplayOrder { get; set; }
        //Price//
        public string Name { get; set; }

        public decimal PriceAdjustment { get; set; }
        public decimal WeightAdjustment { get; set; }
        public int ProductMappingId { get; set; }
    }
}
