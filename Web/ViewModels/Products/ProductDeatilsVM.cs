﻿using Core.Entites;
using Core.Entites.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.ViewModels.Products
{
    public class ProductDeatilsVM
    {
        public Product product { get; set; }
        public IEnumerable<ProductAttributeMapping> productAttributeMappings { get; set; }
    }
}
