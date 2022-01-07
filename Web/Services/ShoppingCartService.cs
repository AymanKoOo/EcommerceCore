using Core.Entites;
using Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.ViewModels.SCart;
using Web.ViewModels.ShopCart;
using Microsoft.AspNetCore.Http;
using Web.ViewModels.ShoppCart;

namespace Web.Services
{
    public class ShoppingCartService:IShoppingCartService
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IUnitOfWork _unitOfWork;

        public ShoppingCartService(IHttpContextAccessor httpContextAccessor, IUnitOfWork unitOfWork)
        {
            this.httpContextAccessor = httpContextAccessor;
            _unitOfWork = unitOfWork;
        }

        public void AddCart(SCart cart)
        {
            var cartList = new List<SCart>();
            var stringObject = httpContextAccessor.HttpContext.Session.GetString("Cart");
            if (!string.IsNullOrEmpty(stringObject))
            {
                cartList = JsonConvert.DeserializeObject<List<SCart>>(stringObject);
            }
            if (cartList.Any(x=>x.ProductID==cart.ProductID))
            {
                cartList.Find(x => x.ProductID == cart.ProductID).Qty=cart.Qty+1;
            }
            else
            {
                cartList.Add( new SCart
                {
                    ProductID = cart.ProductID,
                    Qty = cart.Qty,
                });
            }

            stringObject = JsonConvert.SerializeObject(cartList);
            httpContextAccessor.HttpContext.Session.SetString("Cart", stringObject);
        }

        public void SubtractFromCart(SCart cart)
        {
            var cartList = new List<SCart>();
            var stringObject = httpContextAccessor.HttpContext.Session.GetString("Cart");
            if (!string.IsNullOrEmpty(stringObject))
            {
                cartList = JsonConvert.DeserializeObject<List<SCart>>(stringObject);
            }
            if (cartList.Any(x => x.ProductID == cart.ProductID)&& cart.Qty>1)
            {
                cartList.Find(x => x.ProductID == cart.ProductID).Qty = cart.Qty - 1;
            }
            if(cartList.Any(x => x.ProductID == cart.ProductID) && cart.Qty == 1)
            {
              var r =  cartList.Find(x => x.ProductID == cart.ProductID);
              cartList.Remove(r);
            }
            stringObject = JsonConvert.SerializeObject(cartList);
            httpContextAccessor.HttpContext.Session.SetString("Cart", stringObject);
        }

        public ShopCart GetCart()
        {
            var stringObject = httpContextAccessor.HttpContext.Session.GetString("Cart");

            var cartList = JsonConvert.DeserializeObject<List<SCart>>(stringObject);
            var ids = new List<int>();
            foreach(var id in cartList)
            {
                ids.Add(id.ProductID);
            }
            var products = _unitOfWork.Product.GetProductByCartList(ids);
            var sCart = new ShopCart();
            //var ProdcutsInCart = new ProductsInCart();
            //var pr = new Product();

            decimal totalPrice = 0;
            int totalItems = 0;
            foreach (var p in products)
            {
                int Qty = cartList.FirstOrDefault(x => x.ProductID == p.Id).Qty;

                var pp = new Product
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price * Qty,
                    Picture = p.productPictures[0].picture.MimeType
                };
                var cart = new ProductsInCart
                {
                    product = pp,
                    Qty = cartList.FirstOrDefault(x => x.ProductID == p.Id).Qty,
                };
               totalPrice = totalPrice + (p.Price * Qty);
               sCart.products.Add(cart);
               totalItems = (totalItems + 1)+Qty;
            }
            sCart.totalPrice = totalPrice;
            sCart.totalItems = totalItems;

            return sCart;
        }


        public void RemoveFromCart(SCart cart)
        {
            var cartList = new List<SCart>();
            var stringObject = httpContextAccessor.HttpContext.Session.GetString("Cart");
            if (!string.IsNullOrEmpty(stringObject))
            {
                cartList = JsonConvert.DeserializeObject<List<SCart>>(stringObject);
            }
            if (cartList.Any(x => x.ProductID == cart.ProductID))
            {
                var product = cartList.Find(x => x.ProductID == cart.ProductID);
                cartList.Remove(product);
            }
            
            stringObject = JsonConvert.SerializeObject(cartList);
            httpContextAccessor.HttpContext.Session.SetString("Cart", stringObject);
        }

    }
}
