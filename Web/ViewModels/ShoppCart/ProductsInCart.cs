using Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.ViewModels.ShoppCart
{
    public class ProductsInCart
    {
        public ProductsInCart()
        {
            product = new Product();
        }
        public Product product { get; set; }
        public int Qty { get; set; }
    }
}
