using Core.Entites;
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
        public string Description { get; set; }
        public decimal UnitPrice { get; set; }
        public string CategoryId { get; set; }
        public bool Checked { get; set; }

        public List<Category> categories { get; set; }
        public CategoryVM Category { get; set; }
    }
}
