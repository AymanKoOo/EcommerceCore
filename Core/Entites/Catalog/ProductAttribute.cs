using Core.Entites.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.Entites.Catalog
{
    public class ProductAttribute : EntityBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<ProductAttributeMapping> ProductAttributeMappings { get; set; }
    }
}
