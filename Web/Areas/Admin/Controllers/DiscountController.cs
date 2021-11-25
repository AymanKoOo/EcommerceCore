using AutoMapper;
using Core.Entites;
using Core.Entites.Discounts;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Areas.Admin.Factories;
using Web.Areas.Admin.ViewModels.Discounts;

namespace Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[Controller]")]
    public class DiscountController : Controller
    {
        readonly private IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IProductModelFactory productModelFactory;

        public IDiscountModelFactory DiscountModelFactory { get; }

        public DiscountController(IUnitOfWork unitOfWork, IMapper mapper, IDiscountModelFactory discountModelFactory, IProductModelFactory ProductModelFactory)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            DiscountModelFactory = discountModelFactory;
            productModelFactory = ProductModelFactory;
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


        [HttpGet]
        [Route("Create")]
        public  async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [Route("Create")]
        public  async Task<IActionResult> Create(Discount model)
        {
            if (ModelState.IsValid)
            {
                //Insert Discount
                // await .InsertDiscountAsync(discount);
                var response =  _unitOfWork.discount.Add(model);
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
                _unitOfWork.discount.Update(model);
                _unitOfWork.Save();
                return Redirect("/");
            }
            return Redirect("/failed");
        }

        [HttpGet("AddProductsDiscount")]
        public async Task<IActionResult> AddProductsDiscount(int discountID, int pageSize=2 , int pageNumber=1 )
        {
            ViewBag.DiscountID = discountID;
            // var products = _unitOfWork.Product.GetAllProducts();
            var productsList = await productModelFactory.PrepareProductNODiscountListModelAsync(pageSize, pageNumber);
            return View(productsList);
        }

        [HttpPost("AddProductsDiscount")]
        public IActionResult AddProductsDiscount(int[] products, int IDdiscount)
        {

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
