using Core.Entites;
using Core.Entites.Catalog;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Areas.Admin.ViewModels.Products;

namespace Web.Areas.Admin.ViewModels.Catalog
{
    public class ACategoryModel:BaseEntityModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Slug { get; set; }

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
        public ProductListModel ProductsList { get; set; }

        public ICollection<CategorySpecificationGroup> CategoryAttributes { get; set; }

        //                 //
        public OrderByFilterOptions OrderFilter { get; set; }

        //               //
     
    }
}
