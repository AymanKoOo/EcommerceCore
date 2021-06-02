using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Core.Entites;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Web.DTOs;
namespace Web.Controllers
{
    [Route("[Controller]")]
    public class ProductsController : Controller
    {

        readonly private IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductsController(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public IActionResult Index()
        {
            return View();
        }

        [Route("AddProduct")]
        [HttpGet]
        public IActionResult AddProduct()
        {
            var ListCategories = _unitOfWork.Category.GetCategories();
            ViewBag.ListCategories = ListCategories;

            return View();
        }

        [Route("AddProduct")]
        [HttpPost]
        public IActionResult AddProduct(ProductDTO productDTO)
        {
            var result = _mapper.Map<Product>(productDTO);

            _unitOfWork.Product.AddProduct(result);
            _unitOfWork.Save();

            return View();
        }

      
        [Route("ProductDetail/{productID}")]
        [HttpGet]
        public IActionResult ProductDetail(int productID)
        {
            var product = _unitOfWork.Product.GetProduct(productID);
            
            var productDTO = _mapper.Map<ProductDTO>(product);

            var obj = new IndexDTO
            {
                productDTO = productDTO
            };

            return View(obj);
        }
    }
}