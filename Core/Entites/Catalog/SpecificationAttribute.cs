using Core.Entites.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.Entites.Catalog
{
    public class SpecificationAttribute : EntityBase
    {
        public string Name { get; set; }

        public int DisplayOrder { get; set; }

        [NotMapped]
        public int SpecificationAttributeGroupId { get; set; }
        /// <summary>
        /// Gets or sets the specification attribute group identifier
        /// </summary>
        public IEnumerable<SpecificationAttributeOption> specificationAttributeOptions { get; set; }
        public SpecificationAttributeGroup SpecificationAttributeGroup { get; set; }
    }
}
