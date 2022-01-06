using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    }
}
