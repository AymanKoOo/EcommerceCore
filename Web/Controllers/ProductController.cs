using AutoMapper;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Areas.Admin.Factories;
using Web.ViewModels.Product;

namespace Web.Controllers
{

    public class ProductController : Controller
    {
        private IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IProductModelFactory _productModelFactory;

        public ProductController(IUnitOfWork unitOfWork, IMapper mapper, IProductModelFactory productModelFactory)
        {
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
            var product = _unitOfWork.Product.GetProduct(productId);

            var productDetailVM = await _productModelFactory.PrepareProductDetailModelAsync(new ProductDeatilsVM(), product);

            return View(productDetailVM);
        }

    }
}
