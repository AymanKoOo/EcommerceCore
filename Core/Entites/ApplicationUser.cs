using Core.Entites.Base;
using Core.Entites.Common;
using Core.Entites.Orders;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entites
{
    public class ApplicationUser: IdentityUser
    {
        public string Country { get; set; }

        public string ProfilePic { get; set; }

        public IEnumerable<Order> orders { get; set; }
        public Address ShippingAddress { get; set; }
    }
}
