using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.ViewModels.Products
{
    public class ProductAttributeMappingVM
    {
        public int AttributeID { get; set; }
        public string Attribute { get; set; }
        public int OptionID { get; set; }
        public string Option { get; set; }
    }
}
