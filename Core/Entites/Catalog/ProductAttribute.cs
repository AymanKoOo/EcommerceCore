﻿using Core.Entites.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entites.Catalog
{
    public class ProductAttribute : EntityBase
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public IEnumerable<ProductAttributeOption> productAttributeOptions { get; set; }
    }
}
