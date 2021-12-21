using Core.Entites.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Areas.Admin.ViewModels.Catalog
{
    public class ASpecificationAttributeOptionModel
    {
        public string Name { get; set; }

        public int DisplayOrder { get; set; }
        public int specificationAttributeId { get; set; }
        public IEnumerable<SpecificationAttribute> specificationAttributes { get; set; }
    }
}
