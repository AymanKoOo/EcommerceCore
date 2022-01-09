using AutoMapper;
using Core.Interfaces;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Areas.Admin.Factories;
using Web.ViewModels.Products;

namespace Web.Controllers
{

    public class ProductController : Controller
    {
        private IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IProductModelFactory _productModelFactory;
        private readonly IPriceCalculationService priceCalculation;

        public ProductController(IUnitOfWork unitOfWork, IMapper mapper, IProductModelFactory productModelFactory, IPriceCalculationService priceCalculation)
        {
            this.priceCalculation = priceCalculation;
     

                 _unitOfWork = unitOfWork;
            _mapper = mapper;
            _productModelFactory = productModelFactory;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("prod")]
        public virtual async Task<IActionResult> ProductDetails(int productId, int updatecartitemid = 0)
        {
            var productDetailVM = await _productModelFactory.PrepareProductDetailModelAsync(new ProductDeatilsVM(), productId);
            return View(productDetailVM);
        }

        [HttpPost("GetExtraProductPriceByAjax")]
        public virtual async Task<IActionResult> GetExtraProductPriceByAjax(List<int> options, int ProductID)
        {
            //_unitOfWork.Product.GetProduct()
            var ExtraPrice = _unitOfWork.productAttributes.getAttributePrices(options);
            var product = _unitOfWork.Product.GetProduct(ProductID);

            var pricingObj = await priceCalculation.GetFinalPriceAsync(product);

            product.Price = pricingObj.finalPrice;
            var finalPrice = ExtraPrice + product.Price;

            return Json(finalPrice);
        }
    }

}






