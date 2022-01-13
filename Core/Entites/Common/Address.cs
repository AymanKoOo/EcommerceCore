using Core.Entites.Base;
using Core.Entites.Orders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entites.Common
{
    public class Address:EntityBase
    {
        public string Country { get; set; }
        public string Street { get; set; }
        public string address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zipcode { get; set; }
        public IEnumerable<Order> BillingOrders { get; set; }
    }
}
