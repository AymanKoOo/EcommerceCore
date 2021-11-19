using Core.Entites.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entites.Discounts
{
    public class DiscountType : EntityBase
    {
        public string Name { get; set; }
        public virtual ICollection<Discount> Discounts { get; set; }
    }
}
