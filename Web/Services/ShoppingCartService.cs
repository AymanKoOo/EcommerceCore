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
using Infrastructure.Services;
using Core.Entites.Catalog;
using Web.ViewModels.Products;

namespace Web.Services
{
    public class ShoppingCartService:IShoppingCartService
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPriceCalculationService priceCalculation;

        public ShoppingCartService(IHttpContextAccessor httpContextAccessor, IUnitOfWork unitOfWork, IPriceCalculationService priceCalculation)
        {
            this.httpContextAccessor = httpContextAccessor;
            _unitOfWork = unitOfWork;
            this.priceCalculation = priceCalculation;
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
                    SelectedAttributes = cart.SelectedAttributes
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

        public async Task<ShopCart> GetCartAsync()
        {
            var stringObject = httpContextAccessor.HttpContext.Session.GetString("Cart");

            var cartList = JsonConvert.DeserializeObject<List<SCart>>(stringObject);
            decimal totalPrice = 0;
            int totalItems = 0; 
            var sCart = new ShopCart();

            var options = new List<ProductAttributeOption>();

            foreach (var product in cartList)
            {
                var ExtraPrice = _unitOfWork.productAttributes.getAttributePrices(product.SelectedAttributes);
                var prod = _unitOfWork.Product.GetProduct(product.ProductID);
                //
                var attributes = await _unitOfWork.productAttributes.GetListProductAttrOptionByID(product.SelectedAttributes);
                //
                int qty = product.Qty;
                var pricingObj = await priceCalculation.GetFinalPriceAsync(prod);
                var FinalPrice = ExtraPrice + pricingObj.finalPrice;
                prod.Price = FinalPrice * qty;
                prod.Picture = prod.productPictures[0].picture.MimeType;

                //var pp = new Product
                //{
                //    Id = prod.Id,
                //    Name = prod.Name,
                //    Price = FinalPrice * qty,
                //    Picture = prod.productPictures[0].picture.MimeType,
                //};
                var listAttrOptions = new List<ProductAttributeMappingVM>();
                foreach (var at in attributes)
                {
                    var attributeOptionMapping = new ProductAttributeMappingVM
                    {
                        Attribute = at.productAttributeMapping.productAttribute.Name,
                        Option = at.Name,
                        AttributeID=at.productAttributeMapping.productAttribute.Id,
                        OptionID = at.Id
                    };
                    listAttrOptions.Add(attributeOptionMapping);
                }
               
                var cart = new ProductsInCart
                {
                    Id = prod.Id,
                    Name = prod.Name,
                    Price = FinalPrice * qty,
                    Picture = prod.productPictures[0].picture.MimeType,
                    Qty = qty,
                    productAttributeOptionsMapping = listAttrOptions
                };
                totalPrice = totalPrice + (prod.Price * qty);
                sCart.products.Add(cart);
                totalItems = (totalItems) + qty;
            }
            sCart.totalPrice = totalPrice;
            sCart.totalItems = totalItems;

            //var products = _unitOfWork.Product.GetProductByCartList(ids);
            //var sCart = new ShopCart();
            //decimal totalPrice = 0;
            //int totalItems = 0;
            //foreach (var p in products)
            //{
            //    int Qty = cartList.FirstOrDefault(x => x.ProductID == p.Id).Qty;

            //    var pp = new Product
            //    {
            //        Id = p.Id,
            //        Name = p.Name,
            //        Price = p.Price * Qty,
            //        Picture = p.productPictures[0].picture.MimeType
            //    };
            //    var cart = new ProductsInCart
            //    {
            //        product = pp,
            //        Qty = cartList.FirstOrDefault(x => x.ProductID == p.Id).Qty,
            //    };
            //   totalPrice = totalPrice + (p.Price * Qty);
            //   sCart.products.Add(cart);
            //   totalItems = (totalItems + 1)+Qty;
            //}
            //sCart.totalPrice = totalPrice;
            //sCart.totalItems = totalItems;

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
