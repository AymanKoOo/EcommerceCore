using AutoMapper;
using Core.Entites.Catalog;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Areas.Admin.Factories;
using Web.Areas.Admin.ViewModels.Discounts;
using Web.ViewModels.Discounts;
using Web.ViewModels.Products;

namespace Web.Controllers
{
    [Route("/dic")]
    public class DiscountController : Controller
    {
        private IUnitOfWork _unitOfWork;
        private readonly IMapper mapper;
        private readonly IDiscountModelFactory _discountModelFactory;

        public DiscountController(IUnitOfWork unitOfWork, IMapper mapper, IDiscountModelFactory discountModelFactory)
        {
            _unitOfWork = unitOfWork;
            this.mapper = mapper;
            _discountModelFactory = discountModelFactory;
        }

        [HttpGet("/discount/{discountSlug}")]
        public async Task<IActionResult> Index(string discountSlug, int pageSize = 2, int pageNumber = 1, int orderBy = 0, int[] specs = null)
        {
           
            //discounts + discount products
            if (pageNumber < 0)
            {
                pageNumber = 1;
            }
            var discount = _unitOfWork.discount.GetDiscountBySlug(discountSlug);

            //prepare model
          
            var attrOption = new List<SpecificationAttributeOption>();

            foreach (var i in specs)
            {
                var option = await _unitOfWork.SpecificationAttributes.GetAttrOptionByID(i);
                if (option != null)
                {
                    attrOption.Add(option);
                }
            }
            var disc = await _discountModelFactory.PrepareDiscountProductListModelAsync(discount.Id, pageSize, pageNumber, orderBy, attrOption);

            var discountVm = new DiscountsVM
            {
                discountProductListModel = disc,
                discount = discount
            };

            return View(discountVm);
        }

        [HttpGet("/discount")]
        public async Task<IActionResult> discount(string discountSlug, int pageSize = 2, int pageNumber = 1, int orderBy = 0, int[] specs = null)
        {

            //discounts + discount products
            if (pageNumber < 0)
            {
                pageNumber = 1;
            }
            var discount = _unitOfWork.discount.GetDiscountBySlug(discountSlug);
            var attrOption = new List<SpecificationAttributeOption>();

            foreach (var i in specs)
            {
                var option = await _unitOfWork.SpecificationAttributes.GetAttrOptionByID(i);
                if (option != null)
                {
                    attrOption.Add(option);
                }
            }

            var disc = await _discountModelFactory.PrepareDiscountProductListModelAsync(discount.Id, pageSize, pageNumber, orderBy, attrOption);
            // var categoryModel = await categoryModelFactory.PrepareCategoryModelAsync(new ACategoryModel(), category, attrOption, orderBy, pageSize, pageNumber);

            var products = mapper.Map<List<ProductsVM>>(disc.Data);

            var metadata = new
            {
                products,
                orderBy,
                specs,
                disc.TotalCount,
                disc.PageSize,
                disc.CurrentPage,
                disc.TotalPages,
                disc.HasNext,
                disc.HasPrevious
            };
            return Ok(metadata);
        }
    }
}
