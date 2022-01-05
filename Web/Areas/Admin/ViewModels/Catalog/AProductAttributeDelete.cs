using Core.Entites.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Areas.Admin.ViewModels.Catalog
{
    public class AProductAttributeDelete
    {
        public List<ProductAttribute> productAttributes { get; set; }

        //public List<int> ProductOptionID { get; set; }
        public int ProductOptionID { get; set; }
        public int ProductID { get; set; }
    }
}
