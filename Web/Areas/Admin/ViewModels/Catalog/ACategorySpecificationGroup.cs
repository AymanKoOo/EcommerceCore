using Core.Entites.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Areas.Admin.ViewModels.Catalog
{
    public class ACategorySpecificationGroup{
        public int CategoryID { get; set; }
        public int specificationAttributeGroupID { get; set; }
        public IEnumerable<SpecificationAttributeGroup> specificationAttributeGroups { get; set; }
        public int DisplayOrder { get; set; }
    }
}
