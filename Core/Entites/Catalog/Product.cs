﻿using Core.Entites.Base;
using Core.Entites.Catalog;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Entites
{
    public class Product:EntityBase
    {

        [Required, StringLength(80)]
        public string Name { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public string ImageFile { get; set; }
        public decimal OldPrice { get; set; }
        public decimal Price { get; set; }
        public int? UnitsInStock { get; set; }
        public bool HasDiscountsApplied { get; set; }
        public double Star { get; set; }
        // n-1 relationships
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public virtual ICollection<DiscountProduct> Discounts { get; set; }

        public List<ProductPicture> productPictures { get; set; }

        public virtual ICollection<ProductSpecificationAttribute> ProductSpecificationAttributes { get; set; }
    }
}
