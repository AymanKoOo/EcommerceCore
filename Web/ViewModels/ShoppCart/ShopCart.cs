using Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.ViewModels.ShoppCart;

namespace Web.ViewModels.ShopCart
{
    public class ShopCart
    {
        public ShopCart()
        {
            products = new List<ProductsInCart>();
        }
        public List<ProductsInCart> products;
        public decimal totalPrice { get; set; }
        public int totalItems { get; set; }
    }
}
