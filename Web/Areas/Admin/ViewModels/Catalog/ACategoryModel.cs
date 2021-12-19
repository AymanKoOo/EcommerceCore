using Core.Entites;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Areas.Admin.ViewModels.Catalog
{
    public class ACategoryModel:BaseEntityModel
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public IFormFile ImgCategory { get; set; }
        public int PictureId { get; set; }

        public int ParentCategoryId { get; set; }
        //                   //
        public bool ShowOnHomepage { get; set; }
        public bool IncludeInTopMenu { get; set; }
        public bool Published { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public DateTime UpdatedOnUtc { get; set; }
        //                 //
        public IList<Category> SubCategories { get; set; }
        public IList<Category> AvailableCategories { get; set; }
        public IEnumerable<Product> Products { get; set; }
        //discounts
    }
}
