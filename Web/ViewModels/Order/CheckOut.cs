using Core.Entites.Common;
using Core.Entites.Payments;
using Core.Entites.Shipping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.ViewModels.ShopCart;

namespace Web.ViewModels.Order
{
    public class CheckOut
    {
        public ShopCartt shopCart { get; set; }
        public IQueryable<Address> shippingAddress { get; set; }
        public List<ShippingMethods> shippingMethods { get; set; }
        public List<PaymentMethods> paymentMethods { get; set; }

        public int shippingAddressId { get; set; }
        public string shippingMethod{ get; set; }
        public string paymentMethod { get; set; }
    }
}
