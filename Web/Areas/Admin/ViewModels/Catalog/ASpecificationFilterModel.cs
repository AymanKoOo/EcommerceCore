using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Areas.Admin.ViewModels.Catalog
{
    public class ASpecificationFilterModel
    {
        public string Attribute { get; set; }
        public List<string> Option { get; set; }
    }
}
