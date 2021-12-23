using Core.Entites.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entites.Catalog
{
    public class SpecificationAttributeGroup : EntityBase
    {
        public string Name { get; set; }
        public int DisplayOrder { get; set; }
        public IEnumerable<SpecificationAttribute> SpecificationAttribute { get; set; }

        public virtual ICollection<CategorySpecificationGroup> CategorySpecificationGroups { get; set; }
    }
}
