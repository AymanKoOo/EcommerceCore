using Core.Entites;
using Core.Entites.Catalog;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Areas.Admin.ViewModels.Categories;

namespace Web.Areas.Admin.ViewModels.Products
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Summary { get; set; }
        public string Picture { get; set; }
        public string Description { get; set; }
        public decimal OldPrice { get; set; }
        public decimal Price { get; set; }
        public string CategoryId { get; set; }
        public bool Checked { get; set; }
        public bool HasDiscountsApplied { get; set; }
        public List<ProductPicture> productPictures { get; set; }
        public List<Category> categories { get; set; }
        public CategoryVM Category { get; set; }
    }
}
