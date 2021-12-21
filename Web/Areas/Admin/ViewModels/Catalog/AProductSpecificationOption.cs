using Core.Entites.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Areas.Admin.ViewModels.Catalog
{
    public class AProductSpecificationOption
    {
        public int ProductID { get; set; }
        public int SpecificationAttributeId { get; set; }
        public IEnumerable<SpecificationAttribute> specificationAttributes { get; set; }
       
        public int SpecificationAttributeOptionId { get; set; }
        public IEnumerable<SpecificationAttributeOption> specificationAttributeOptions { get; set; }
        public int DisplayOrder { get; set; }
    }
}
