using Core.Entites.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Areas.Admin.ViewModels.Catalog
{
    public class AProductAttributeAdd
    {
        public List<ProductAttribute> productAttributes { get; set; }
        public int ProductId { get; set; }
        public int ProductAttributeId { get; set; }
    }
}
