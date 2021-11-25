using AutoMapper;
using Core.Entites;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Areas.Admin.Factories;
using Web.Areas.Admin.ViewModels;
using Web.Areas.Admin.ViewModels.Products;

namespace Web.Areas.Admin.Controllers
{

    [Area("Admin")]
    [Route("Admin/[Controller]")]
    public class Product : Controller
    {


        readonly private IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public IProductModelFactory ProductModelFactory { get; }

        public Product(IUnitOfWork unitOfWork, IMapper mapper, IProductModelFactory ProductModelFactory)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            this.ProductModelFactory = ProductModelFactory;
        }

        public async Task<IActionResult> Index(int pageSize=1, int pageNumber=1)
        {
            // var products = _unitOfWork.Product.GetAllProducts();
            var productsList = await ProductModelFactory.PrepareDiscountProductListModelAsync(pageSize, pageNumber);
            return View(productsList);
        }

        [HttpPost]
        public IActionResult Index(int products)
        {
            
            return View();
        }

        [HttpGet("EditProduct")]
        public IActionResult EditProduct(int productID)
        {
            var product = _unitOfWork.Product.GetProduct(productID);
            var categories = _unitOfWork.Category.GetAllCategories();

            var model = new EditProductVM
            {
                Id = productID,
                Name = product.Name,
                Description = product.Description,
                ImageFile = product.ImageFile,
                UnitPrice = product.UnitPrice,
                // n-1 relationships
                CategoryId = product.CategoryId,
                categories = categories
            };
            return View(model);
        }

        [HttpPost("EditProduct")]
        public IActionResult EditProduct(Core.Entites.Product product)
        {
            var Product = _unitOfWork.Product.GetProduct(product.Id);
            Product.ImageFile = product.ImageFile;
            Product.Name = product.Name;
            Product.UnitPrice = product.UnitPrice;

            Product.CategoryId = product.CategoryId;
            Product.Description = product.Description;

            _unitOfWork.Product.Update(Product);
            _unitOfWork.Save();
            return Redirect("/");
        }


        [HttpGet("AddProduct")]
        public IActionResult AddProduct()
        {
            var categories = _unitOfWork.Category.GetAllCategories();

            var model = new EditProductVM
            {
                categories = categories
            };
            return View(model);
        }
        [HttpPost("AddProduct")]
        public IActionResult AddProduct(Core.Entites.Product product)
        {
           
            _unitOfWork.Product.Add(product);
            _unitOfWork.Save();
            return Redirect("/");
        }

        [HttpGet("DeleteProduct")]
        public IActionResult DeleteProduct(int productID)
        {
            var product =  _unitOfWork.Product.GetProduct(productID);
            _unitOfWork.Product.Delete(product);
            _unitOfWork.Save();
            return Redirect("/");
        }

        [HttpPost("DeleteProducts")]
        public IActionResult DeleteProducts(int[] productID)
        {

            foreach(var id in productID)
            {
                var product = _unitOfWork.Product.GetProduct(id);
                _unitOfWork.Product.Delete(product);
            }

            _unitOfWork.Save();
            return Redirect("/");
        }

      
    }
}
