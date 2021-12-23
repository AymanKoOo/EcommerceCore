using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Core.Entites.Base;
using Core.Entites.Catalog;

namespace Core.Entites
{
    public class Category : EntityBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int PictureId { get; set; }
        public int ParentCategoryId { get; set; }

        public string MetaDescription { get; set; }
        public string MetaTitle { get; set; }

        public bool ShowOnHomepage { get; set; }
        public bool IncludeInTopMenu { get; set; }
        public bool Published { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public DateTime UpdatedOnUtc { get; set; }

        public List<CategoryPicture> categoryPictures { get; set; }
        
        public virtual ICollection<CategorySpecificationGroup> CategorySpecificationGroups { get; set; }
    }
}
