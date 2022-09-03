using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entites.Catalog
{
    public class DealDiscount
    {
        public int dealID { get; set; }
        public Deal deal { get; set; }

        public int discountID { get; set; }
        public Discount discount { get; set; }
    }
}
