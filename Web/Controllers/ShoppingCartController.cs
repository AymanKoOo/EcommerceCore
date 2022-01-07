using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Services;
using Web.ViewModels.Products;
using Web.ViewModels.SCart;

namespace Web.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IShoppingCartService _shoppingCartService;

        public ShoppingCartController(IShoppingCartService shoppingCartService)
        {
            _shoppingCartService = shoppingCartService;
        }
        public IActionResult Index()
        {
            return View();
        }
  
        [HttpPost("AddCart")]
        public IActionResult AddCart(SCart model)
        {
            _shoppingCartService.AddCart(model);
            return RedirectToAction("Cart");
        }

    
        [HttpGet("Cart")]
        public IActionResult Cart()
        {
            var model = _shoppingCartService.GetCart();
            return View(model);
        }

        [HttpPost("AddQantityCartAjaxx")]
        public IActionResult AddQantityCartAjaxx(SCart model)
        {
             _shoppingCartService.AddCart(model);
            var objectCart = _shoppingCartService.GetCart();
            var jsonStr = JsonConvert.SerializeObject(objectCart);
            return Json(jsonStr);
        }

        [HttpPost("SubtractQantityCartAjaxx")]
        public IActionResult SubtractQantityCartAjaxx(SCart model)
        {
            _shoppingCartService.SubtractFromCart(model);
            var objectCart = _shoppingCartService.GetCart();
            var jsonStr = JsonConvert.SerializeObject(objectCart);
            return Json(jsonStr);
        }
      
        [HttpPost("RemoveProductCartAjaxx")]
        public IActionResult RemoveProductCartAjaxx(SCart model)
        {
            _shoppingCartService.RemoveFromCart(model);
            var objectCart = _shoppingCartService.GetCart();
            var jsonStr = JsonConvert.SerializeObject(objectCart);
            return Json(jsonStr);
        }
    }
}
