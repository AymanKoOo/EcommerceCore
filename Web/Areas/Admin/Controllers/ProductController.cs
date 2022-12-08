using AutoMapper;
using Core.Entites;
using Core.Entites.Catalog;
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
using Web.Areas.Admin.ViewModels.Catalog;
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
        private readonly IProductAttributeModelFactory _productAttributeModelFactory;
        private readonly IPictureService picture;
        private readonly IWebHostEnvironment environment;
        private readonly ISlugService _slugService;

        public IProductModelFactory _productModelFactory { get; }

        public ProductController(IUnitOfWork unitOfWork, IMapper mapper, ISlugService slugService, IProductAttributeModelFactory productAttributeModelFactory , IProductModelFactory ProductModelFactory, IPictureService picture, IWebHostEnvironment environment)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            this._productAttributeModelFactory = productAttributeModelFactory;
            this._productModelFactory = ProductModelFactory;
            this.picture = picture;
            this.environment = environment;
            _slugService = slugService;
        }

        public async Task<IActionResult> Index(int pageSize=5, int pageNumber=1)
        {
            // var products = _unitOfWork.Product.GetAllProducts();
            var productsList = await _productModelFactory.PrepareProductListModelAsync(pageSize, pageNumber);
            return View(productsList);
        }


        [HttpGet("EditProduct")]
        public async Task<IActionResult> EditProduct(int productID)
        {
            var product = _unitOfWork.Product.GetProduct(productID);

            var model = await _productModelFactory.PrepareProductModelAsync(null, product);

            return View(model);
        }

        [HttpPost("EditProduct")]
        public async Task<IActionResult> EditProduct(ProductDTO model)
        {
           if (ModelState.IsValid)
            {
                var Product = _unitOfWork.Product.GetProduct(model.Id);

                var picName="";
                //Add Picture
                if (model.PictureFile != null)
                {
                    picName = await picture.UploadPictureAsync(model.PictureFile, environment.WebRootPath);

                    var picObj = new Picture
                    {
                        MimeType = picName,
                    };

                    await _unitOfWork.picture.Add(picObj);
                }
                _unitOfWork.Save();
                var ProductPics = _unitOfWork.Product.GetProductPictureByProductID(Product.Id);

                foreach (var p in ProductPics)
                {
                    p.DisplayOrder = 0;
                    _unitOfWork.Product.UpdateProductPicture(p);
                }

                if (model.PictureFile != null)
                {
                    var pic = await _unitOfWork.picture.getPicByName(picName);
                    
                    var prod = await _unitOfWork.Product.GetProductBySlug(Product.Slug);

                    await _unitOfWork.Product.AddPicture(prod.Id, pic.Id);
                }
                _unitOfWork.Save();

           
                //Add Main Picture               
                var MainPicID = model.MainpictureID;
                if (MainPicID != 0)
                {
                    foreach (var p in ProductPics)
                    {
                        p.DisplayOrder = 0;
                        _unitOfWork.Product.UpdateProductPicture(p);
                    }
                    var Mpic = _unitOfWork.Product.GetSingleProductPictureByProductID(MainPicID);
                    Mpic.DisplayOrder = 1;
                }
               
                //end//
                Product.Name = model.Name;
                Product.Price = model.Price;

                Product.CategoryId = model.CategoryId;
                Product.Description = model.Description;

                _unitOfWork.Product.Update(Product);
                _unitOfWork.Save();
            }
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
            var picName = await picture.UploadPictureAsync(model.PictureFile, environment.WebRootPath);

            var picObj = new Picture
            {
                MimeType = picName,
            };

            await _unitOfWork.picture.Add(picObj);

            var product = _mapper.Map<Product>(model);
         
            string ProductSlug = _slugService.createSlug(model.Name);

            string uniqueSlug = _unitOfWork.Product.MakeDealSlugUnique(ProductSlug);

            product.Slug = uniqueSlug;

            await _unitOfWork.Product.Add(product);

            _unitOfWork.Save();

            var pic = await _unitOfWork.picture.getPicByName(picName);
            
            var prod = await _unitOfWork.Product.GetProductBySlug(uniqueSlug);

            await _unitOfWork.Product.AddPicture(prod.Id, pic.Id);

            _unitOfWork.Save();
            return Redirect("/");
        }

        [HttpGet("DeleteProduct")]
        public IActionResult DeleteProduct(int productID)
        {
            var product = _unitOfWork.Product.GetProduct(productID);
            product.Deleted = true;
            _unitOfWork.Product.Update(product);
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



        #region Product Specfication

        //AddProductSpecificationAttribute

        [HttpGet("ProductSpecAttributeAdd")]
        public async Task<IActionResult> ProductSpecAttributeAdd(int productID)
        {
            var model = await _productModelFactory.PrepareProductSpecifcationAttr();
            model.ProductID = productID;
            return View(model);
        }

        [HttpPost("ProductSpecAttributeAdd")]
        public async  Task<IActionResult> ProductSpecAttributeAdd(AProductSpecificationOption model)
        {

            var productSpec = _mapper.Map<ProductSpecificationAttribute>(model);
            var product = _unitOfWork.Product.GetProduct(model.ProductID);
            var attrOption = await _unitOfWork.SpecificationAttributes.GetAttrOptionByID(model.SpecificationAttributeOptionId);
            productSpec.specificationAttributeOption = attrOption;
            productSpec.product = product;
            await _unitOfWork.Product.AddProductSpecificationAttribute(productSpec);
            _unitOfWork.Save();
            return Redirect("/");
        }

        #endregion


        ////////////////////////////AddProductAttribute//////////////////////////

        [HttpGet("ProductAttributeAdd")]
        public async Task<IActionResult> ProductAttributeAdd(int productID)
        {
            var model = await _productAttributeModelFactory.PrepareProductAttributeAdd(productID);
            model.ProductId = productID;
            return View(model);
        }

        [HttpPost("ProductAttributeAdd")]
        public async Task<IActionResult> ProductAttributeAdd(AProductAttributeAdd model)
        {
            var mappedModel = _mapper.Map<ProductAttributeMapping>(model);
            //add to product-attrMaping
            await _unitOfWork.Product.AddProductAttributeMapping(mappedModel);
            _unitOfWork.Save();
            return View("");
        }

        [HttpGet("ProductAttributeDelete")]
        public  IActionResult ProductAttributeDelete(int mapID)
        {
             _unitOfWork.Product.deleteProductAttrMapping(mapID);

                _unitOfWork.Save();
                return View("");
        }
        //////////////////////////ProductAttributeOptionAdd//////////////////////


        [HttpGet("ProductAttributeOptionAdd")]
        public async Task<IActionResult> ProductAttributeOptionAdd(int ProductAttributeMappingEdit)
        {
            var model = await _productModelFactory.ProductAttributeMappingOptionModel(new AProductAttrMappingOption(), ProductAttributeMappingEdit);
            return View(model);
        }

        [HttpPost("ProductAttributeOptionAdd")]
        public async Task<IActionResult> ProductAttributeOptionAdd(AProductAttrMappingOption model)
        {
            var optionMapper = _mapper.Map<ProductAttributeOption>(model);
            await _unitOfWork.productAttributes.CreateProductAttributeOption(optionMapper);

            _unitOfWork.Save();

            return View("");
        }


        [HttpGet("ProductAttributeOptionDelete")]
        public async Task<IActionResult> ProductAttributeOptionDelete(int optionId)
        {
            _unitOfWork.productAttributes.DeleteProductOptionById(optionId);
            _unitOfWork.Save();

            return View("/");
        }




        [HttpGet("FetchAttributeOptions")]
        public async Task<IActionResult> FetchAttributeOptions(int attributeID)
        {
            var att = await _unitOfWork.SpecificationAttributes.GetSpecAttrByID(attributeID);
            var options = att.specificationAttributeOptions;

            List<OptionList> ol = new List<OptionList>();

            foreach (var item in options)
            {
                OptionList o = new OptionList();
                o.id = item.Id;
                o.name = item.Name;
                ol.Add(o);
            }
            return Ok(ol);
        }


        [HttpGet("ProductPictureDelete")]
        public async Task<IActionResult> ProductPictureDelete(int id)
        {
            var pic = await _unitOfWork.picture.getPicById(id);
            _unitOfWork.picture.Delete(pic);
            _unitOfWork.Save();
            return Redirect("/");
        }
    }
}
