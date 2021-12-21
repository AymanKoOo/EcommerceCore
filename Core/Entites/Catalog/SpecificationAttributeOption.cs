using Core.Entites.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.Entites.Catalog
{
    public class SpecificationAttributeOption: EntityBase
    {
        public string Name { get; set; }

        public int DisplayOrder { get; set; }

        [NotMapped]
        public int specificationAttributeId { get; set; }

        public SpecificationAttribute specificationAttribute { get; set; }
        public virtual ICollection<ProductSpecificationAttribute> ProductSpecificationAttributes { get; set; }
    }
}
