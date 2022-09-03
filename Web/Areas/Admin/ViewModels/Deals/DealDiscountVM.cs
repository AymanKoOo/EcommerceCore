using Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Areas.Admin.ViewModels.Deals
{
    public class DealDiscountVM
    {
        public int DealID { get; set; }
        public IEnumerable<Discount> discounts { get; set; }
    }
}
