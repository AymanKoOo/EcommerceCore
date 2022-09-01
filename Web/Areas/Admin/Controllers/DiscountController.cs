using AutoMapper;
using Core.Entites;
using Core.Entites.Discounts;
using Core.Interfaces;
using Infrastructure.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Areas.Admin.Factories;
using Web.Areas.Admin.ViewModels.Discounts;
using Web.DTOs;

namespace Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[Controller]")]
    public class DiscountController : Controller
    {
        readonly private IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment environment;
        private readonly IPictureService picture;
        private readonly IProductModelFactory productModelFactory;
        private readonly ICategoryModelFactory categoryModelFactory;

        public IDiscountModelFactory DiscountModelFactory { get; }

        public DiscountController(IUnitOfWork unitOfWork, IMapper mapper, IWebHostEnvironment environment, 
            IPictureService picture, IDiscountModelFactory discountModelFactory,
            IProductModelFactory ProductModelFactory,
            ICategoryModelFactory CategoryModelFactory)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            this.environment = environment;
            this.picture = picture;
            DiscountModelFactory = discountModelFactory;
            productModelFactory = ProductModelFactory;
            categoryModelFactory = CategoryModelFactory;
        }


        public IActionResult Index()
        {
            var discounts = _unitOfWork.discount.GetAll();
            return View(discounts);
        }


        [HttpPost]
        [Route("GetDiscountProducts")]
        public async Task<IActionResult> GetDiscountProducts(int discountID,int pageSize,int pageNumber)
        {
            var products = await DiscountModelFactory.PrepareDiscountProductListModelAsync(discountID, pageSize, pageNumber);
            return Ok(products);
        }


        [HttpPost]
        [Route("GetDiscountCategories")]
        public async Task<IActionResult> GetDiscountCategories(int discountID, int pageSize, int pageNumber)
        {
            var categories = await DiscountModelFactory.PrepareDiscountCategoryListModelAsync(discountID, pageSize, pageNumber);
            return Ok(categories);
        }

        [HttpGet]
        [Route("Create")]
        public  async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [Route("Create")]
        public  async Task<IActionResult> Create(DiscountDTO model)
        {
            //Upload discount image
            var picName = await picture.UploadPictureAsync(model.PictureFile, environment.WebRootPath);
            var picObj = new Picture
            {
                MimeType = picName,
            };
            await _unitOfWork.picture.Add(picObj);

            //  await _unitOfWork.picture.Add(picObj);
            if (ModelState.IsValid)
            {
                var discount = _mapper.Map<Discount>(model);
                discount.picture = picObj;
                model.UsePercentage = true;
                discount.slug = Core.Entites.Discount.CreateDiscountslug(model.Name);
                var response = _unitOfWork.discount.Add(discount);
                _unitOfWork.Save();
                return Redirect("/");
            }
            return Redirect("/failed");
        }

        
        [HttpGet]
        [Route("Delete")]
        public async Task<IActionResult> Delete(int Id)
        {
            if (ModelState.IsValid)
            {
                //Insert Discount
                // await .InsertDiscountAsync(discount);
                var discount = _unitOfWork.discount.GetByID(Id);
                _unitOfWork.discount.RemoveDiscountsFromCategoriesProducts(Id);
                _unitOfWork.discount.Delete(discount);
                _unitOfWork.Save();
                return Redirect("/");
            }
            return Redirect("/failed");
        }
        [HttpGet]
        [Route("Edit")]
        public async Task<IActionResult> Edit(int Id)
        {
            var discount = _unitOfWork.discount.GetByID(Id);
            return View(discount);
        }

        [HttpPost]
        [Route("Edit")]
        public async Task<IActionResult> Edit(Discount model)
        {
            if (ModelState.IsValid)
            {
                //Insert Discount
                // await .InsertDiscountAsync(discount);
                // var discount = _unitOfWork.discount.GetByID(model.Id);
                var discountUpdated = _unitOfWork.discount.GetByID(model.Id);

                discountUpdated.DiscountTypeId = model.DiscountTypeId;
                discountUpdated.Name = model.Name;
                discountUpdated.DiscountPercentage = model.DiscountPercentage;

                _unitOfWork.discount.Update(discountUpdated);
                _unitOfWork.Save();
                return Redirect("/");
            }
            return Redirect("/failed");
        }

        [HttpGet("AddProductsDiscount")]
        public async Task<IActionResult> AddProductsDiscount(int discountID, int pageSize=2 , int pageNumber=1 )
        {
            ViewBag.DiscountID = discountID;
            var discount = _unitOfWork.discount.GetByID(discountID);

            if (discount.DiscountTypeId == (int) DiscountTyp.AssignedToProducts)
            {
                // var products = _unitOfWork.Product.GetAllProducts();
                var productsList = await productModelFactory.PrepareProductNODiscountListModelAsync(pageSize, pageNumber);
                return View(productsList);
            }
            else
            {
                return Redirect("/failed");
            }
        }

        [HttpPost("AddProductsDiscount")]
        public IActionResult AddProductsDiscount(int[] products, int IDdiscount)
        {
            var discount = _unitOfWork.discount.GetByID(IDdiscount);
            var discountTypeID = discount.DiscountTypeId;

            if (discountTypeID == 1)
            {
                _unitOfWork.discount.RemoveDiscountsFromCategoriesProducts(IDdiscount);
            }

            for (int i = 0; i < products.Length; i++)
            {
                var product = _unitOfWork.Product.GetProduct(products[i]);
                _unitOfWork.Product.AddProductTODiscount(product, IDdiscount);
                product.HasDiscountsApplied = true;
                _unitOfWork.Product.Update(product);
            }
            _unitOfWork.Save();
            return View("/");
        }

        [HttpPost("RemoveProductsDiscount")]
        public async Task<IActionResult> RemoveProductsDiscount(int[] productID)
        {
            // var products = _unitOfWork.Product.GetAllProducts();
            for (int i = 0; i < productID.Length; i++)
            {
                var product = _unitOfWork.Product.GetProduct(productID[i]);
                product.HasDiscountsApplied = false;
                _unitOfWork.Product.Update(product);
                _unitOfWork.discount.RemoveProductToDiscount(product);
            }
            _unitOfWork.Save();
            return View();
        }

        ///////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////
        [HttpGet("AddCategoryDiscount")]
        public async Task<IActionResult> AddCategoryDiscount(int discountID, int pageSize = 2, int pageNumber = 1)
        {
            ViewBag.DiscountID = discountID;
            var discount = _unitOfWork.discount.GetByID(discountID);

            if (discount.DiscountTypeId == (int)DiscountTyp.AssignedToCategories)
            {
                // var products = _unitOfWork.Product.GetAllProducts();
                var categories = await categoryModelFactory.PrepareCategoryNODiscountListModelAsync(pageSize, pageNumber);
                return View(categories);
            }
            else
            {
                return Redirect("/failed");
            }
        }

        [HttpPost("AddCategoryDiscount")]
        public async Task<IActionResult> AddCategoriesDiscount(int[] categories, int IDdiscount)
        {
            var discount = _unitOfWork.discount.GetByID(IDdiscount);
            var discountTypeID = discount.DiscountTypeId;

            if (discountTypeID == 2)
            {
                _unitOfWork.discount.RemoveDiscountsFromCategoriesProducts(IDdiscount);
            }
            for (int i = 0; i < categories.Length; i++)
            {
                var category = await _unitOfWork.Category.GetCategory(categories[i]);
                await _unitOfWork.Category.AddCategoryTODiscount(category, IDdiscount);
                category.HasDiscountsApplied = true;
                _unitOfWork.Category.Update(category);
            }
            _unitOfWork.Save();
            return View("/");
        }

        [HttpPost("RemoveCategoryDiscount")]
        public async Task<IActionResult> RemoveCategoryDiscount(int[] categoryIds)
        {
            // var products = _unitOfWork.Product.GetAllProducts();
            for (int i = 0; i < categoryIds.Length; i++)
            {
                var category = await _unitOfWork.Category.GetCategory(categoryIds[i]);
                category.HasDiscountsApplied = false;
                _unitOfWork.Category.Update(category);
                _unitOfWork.discount.RemoveCategoryToDiscount(category);
            }
            _unitOfWork.Save();
            return View();
        }

        #region Create Discount Type

        //[HttpGet]
        //[Route("TypeCreate")]
        //public async Task<IActionResult> TypeCreate()
        //{

        //    return View();
        //}



        //[HttpPost]
        //[Route("TypeCreate")]
        //public  async Task<IActionResult> TypeCreate(DiscountType model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        //discount services add

        //        return Redirect("/");
        //    }
        //    return Redirect("/failed");
        //}
        #endregion

        //public virtual async Task<IActionResult> Edit(int id)
        //{
        //    if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageDiscounts))
        //        return AccessDeniedView();

        //    //try to get a discount with the specified id
        //    var discount = await _discountService.GetDiscountByIdAsync(id);
        //    if (discount == null)
        //        return RedirectToAction("List");

        //    //prepare model
        //    var model = await _discountModelFactory.PrepareDiscountModelAsync(null, discount);

        //    return View(model);
        //}

        //[HttpPost, ParameterBasedOnFormName("save-continue", "continueEditing")]
        //public virtual async Task<IActionResult> Edit(DiscountModel model, bool continueEditing)
        //{
        //    if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageDiscounts))
        //        return AccessDeniedView();

        //    //try to get a discount with the specified id
        //    var discount = await _discountService.GetDiscountByIdAsync(model.Id);
        //    if (discount == null)
        //        return RedirectToAction("List");

        //    if (ModelState.IsValid)
        //    {
        //        var prevDiscountType = discount.DiscountType;
        //        discount = model.ToEntity(discount);
        //        await _discountService.UpdateDiscountAsync(discount);

        //        //clean up old references (if changed) 
        //        if (prevDiscountType != discount.DiscountType)
        //        {
        //            switch (prevDiscountType)
        //            {
        //                case DiscountType.AssignedToSkus:
        //                    await _productService.ClearDiscountProductMappingAsync(discount);
        //                    break;
        //                case DiscountType.AssignedToCategories:
        //                    await _categoryService.ClearDiscountCategoryMappingAsync(discount);
        //                    break;
        //                case DiscountType.AssignedToManufacturers:
        //                    await _manufacturerService.ClearDiscountManufacturerMappingAsync(discount);
        //                    break;
        //                default:
        //                    break;
        //            }
        //        }

        //        //activity log
        //        await _customerActivityService.InsertActivityAsync("EditDiscount",
        //            string.Format(await _localizationService.GetResourceAsync("ActivityLog.EditDiscount"), discount.Name), discount);

        //        _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.Promotions.Discounts.Updated"));

        //        if (!continueEditing)
        //            return RedirectToAction("List");

        //        return RedirectToAction("Edit", new { id = discount.Id });
        //    }

        //    //prepare model
        //    model = await _discountModelFactory.PrepareDiscountModelAsync(model, discount, true);

        //    //if we got this far, something failed, redisplay form
        //    return View(model);
        //}

        //[HttpPost]
        //public virtual async Task<IActionResult> Delete(int id)
        //{
        //    if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageDiscounts))
        //        return AccessDeniedView();

        //    //try to get a discount with the specified id
        //    var discount = await _discountService.GetDiscountByIdAsync(id);
        //    if (discount == null)
        //        return RedirectToAction("List");

        //    //applied to products
        //    var products = await _productService.GetProductsWithAppliedDiscountAsync(discount.Id, true);

        //    await _discountService.DeleteDiscountAsync(discount);

        //    //update "HasDiscountsApplied" properties
        //    foreach (var p in products)
        //        await _productService.UpdateHasDiscountsAppliedAsync(p);

        //    //activity log
        //    await _customerActivityService.InsertActivityAsync("DeleteDiscount",
        //        string.Format(await _localizationService.GetResourceAsync("ActivityLog.DeleteDiscount"), discount.Name), discount);

        //    _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.Promotions.Discounts.Deleted"));

        //    return RedirectToAction("List");
        //}        //public virtual async Task<IActionResult> List()
        //{
        //    if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageDiscounts))
        //        return AccessDeniedView();

        //    //whether discounts are ignored
        //    if (_catalogSettings.IgnoreDiscounts)
        //        _notificationService.WarningNotification(await _localizationService.GetResourceAsync("Admin.Promotions.Discounts.IgnoreDiscounts.Warning"));

        //    //prepare model
        //    var model = await _discountModelFactory.PrepareDiscountSearchModelAsync(new DiscountSearchModel());

        //    return View(model);
        //}

        //[HttpPost]
        //public virtual async Task<IActionResult> List(DiscountSearchModel searchModel)
        //{
        //    if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageDiscounts))
        //        return await AccessDeniedDataTablesJson();

        //    //prepare model
        //    var model = await _discountModelFactory.PrepareDiscountListModelAsync(searchModel);

        //    return Json(model);
        //}





    }
}
