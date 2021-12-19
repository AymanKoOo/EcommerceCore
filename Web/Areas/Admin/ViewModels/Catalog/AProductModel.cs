using Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Areas.Admin.ViewModels.Catalog
{
    public class AProductModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string PictureFile { get; set; }
        public decimal Price { get; set; }
        // n-1 relationships
        public int CategoryId { get; set; }
        public Category category { get; set; }
        public List<Category> categories { get; set; }
    }
}
