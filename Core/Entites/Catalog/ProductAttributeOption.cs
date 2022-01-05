using Core.Entites.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
        //Picture//
        public string ImageSquaresPictureId { get; set; } // from product Pictures

        public string PicturePath { get; set; }
        public int ProductAttributeMappingId { get; set; }
        public ProductAttributeMapping productAttributeMapping { get; set; }
    }
}
