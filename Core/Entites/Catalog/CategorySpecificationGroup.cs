using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entites.Catalog
{
    public class CategorySpecificationGroup
    {
        public int CategoryId { get; set; }
        public Category category { get; set; }

        public int SpecificationAttributeGroupId { get; set; }
        public SpecificationAttributeGroup specificationAttributeGroup { get; set; }
    }
}
