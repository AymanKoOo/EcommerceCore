using AutoMapper;
using Core.Entites;
using Core.Interfaces;
using Infrastructure.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Areas.Admin.Factories;
using Web.Areas.Admin.ViewModels;
using Web.Areas.Admin.ViewModels.Products;
using Web.DTOs;

namespace Web.Areas.Admin.Controllers
{

    [Area("Admin")]
    [Route("Admin/[Controller]")]
    public class ProductController : Controller
    {


        readonly private IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IPictureService picture;
        private readonly IWebHostEnvironment environment;

        public IProductModelFactory ProductModelFactory { get; }

        public ProductController(IUnitOfWork unitOfWork, IMapper mapper, IProductModelFactory ProductModelFactory, IPictureService picture, IWebHostEnvironment environment)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            this.ProductModelFactory = ProductModelFactory;
            this.picture = picture;
            this.environment = environment;
        }

        public async Task<IActionResult> Index(int pageSize=5, int pageNumber=1)
        {
            // var products = _unitOfWork.Product.GetAllProducts();
            var productsList = await ProductModelFactory.PrepareProductListModelAsync(pageSize, pageNumber);
            return View(productsList);
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
            //    categories = categories
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
        public async Task<IActionResult> AddProduct(ProductDTO model)
        {
            var picName = await picture.UploadPictureAsync(model.ImageFile, environment.WebRootPath);

            var picObj = new Picture
            {
                MimeType = picName,
            };

            await _unitOfWork.picture.Add(picObj);

            var product = _mapper.Map<Product>(model);
            await _unitOfWork.Product.Add(product);

            _unitOfWork.Save();

            var pic = await _unitOfWork.picture.getPicByName(picName);

            var prod = await _unitOfWork.Product.GetProductByName(model.Name);

            await _unitOfWork.Product.AddPicture(prod.Id, pic.Id);

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
