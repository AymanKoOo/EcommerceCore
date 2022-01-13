using Core.Entites.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entites.Shipping
{
    public class ShippingMethods : EntityBase
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public int DisplayOrder { get; set; }
    }
}
