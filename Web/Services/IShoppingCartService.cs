using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.ViewModels.SCart;
using Web.ViewModels.ShopCart;

namespace Web.Services
{
    public interface IShoppingCartService
    {
        public void AddCart(SCart cart);
        public ShopCart GetCart();
    }
}
