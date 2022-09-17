using Core.Entites.Catalog;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Areas.Admin.Factories;

namespace Web.Controllers
{
    [Route("/dic")]
    public class DiscountController : Controller
    {
        private IUnitOfWork _unitOfWork;
        private readonly IDiscountModelFactory _discountModelFactory;

        public DiscountController(IUnitOfWork unitOfWork, IDiscountModelFactory discountModelFactory)
        {
            _unitOfWork = unitOfWork;
            _discountModelFactory = discountModelFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string discountSlug, int pageSize = 2, int pageNumber = 1, int orderBy = 0, int[] specs = null)
        {
            var discount = _unitOfWork.discount.GetDiscountBySlug(discountSlug);
            //discounts + discount products
            if (pageNumber < 0)
            {
                pageNumber = 1;
            }
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
            return View(disc);
        }


        [HttpGet("/disc/{discountSlug}")]
        public async Task<IActionResult> Discount(string discountSlug, int pageSize = 2, int pageNumber = 1, int orderBy = 0, int[] specs = null)
        {
            return View();
        }
    }
}
