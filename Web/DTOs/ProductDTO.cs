using Core.Entites;
using Core.Entites.Catalog;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public decimal OldPrice { get; set; }
        public decimal Price { get; set; }
        public string CategoryId { get; set; }
        public IFormFile PictureFile { get; set; }
        public string ImageFile { get; set; }

        public bool HasDiscountsApplied { get; set; }

        public Category Category { get; set; }

        public virtual List<DiscountProduct> Discounts { get; set; }

        public List<ProductPicture> productPictures { get; set; }

    }
}
