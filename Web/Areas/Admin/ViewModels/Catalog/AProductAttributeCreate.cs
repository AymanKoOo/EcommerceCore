﻿using Core.Entites.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Areas.Admin.ViewModels.Catalog
{
    public class AProductAttributeCreate
    {
        public int ProductID { get; set; }
        public int ProductAttributeId { get; set; }
        public IEnumerable<ProductAttribute> productAttributes { get; set; }

        public int ProductAttributeOptionId { get; set; }
        public IEnumerable<ProductAttributeOption> productAttributeOptions { get; set; }
        public int DisplayOrder { get; set; }
    }
}
