using AutoMapper;
using Core.Entites.Catalog;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Areas.Admin.Factories;
using Web.Areas.Admin.ViewModels.Deals;
using Web.Areas.Admin.ViewModels.Discounts;
using Web.ViewModels.Deals;
using Web.ViewModels.Products;

namespace Web.Controllers
{
    [Route("/deals")]

    public class DealsController : Controller
    {
        private IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IDiscountModelFactory _discountModelFactory;

        public DealsController(IUnitOfWork unitOfWork, IMapper mapper, IDiscountModelFactory discountModelFactory)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _discountModelFactory = discountModelFactory;
        }

        public async Task<IActionResult> Index(string dealSlug, int pageSize = 2, int pageNumber = 1, int orderBy = 0, int[] specs = null)
        {
            //discounts + discount products
            if (pageNumber < 0)
            {
                pageNumber = 1;
            }
            var deal = _unitOfWork.dealRepo.geBySlug(dealSlug);

            //prepare model
            List<int> discountIds = new List<int>();
            foreach (var id in deal.DealDiscounts)
            {
                discountIds.Add(id.discountID);
            }
            var disc = await _discountModelFactory.PrepareDiscountSProductListModelAsync(discountIds, pageSize, pageNumber);

            var dealVm = new DealsVM
            {
                discountProductListModel = disc,
                deal = deal
            };

            return View(dealVm);
        }

        [HttpGet("/d/{dealSlug}")]
        public async Task<IActionResult> deals(string dealSlug, int pageSize = 2, int pageNumber = 1, int orderBy = 0, int[] specs = null)
        {

            //discounts + discount products
            if (pageNumber < 0)
            {
                pageNumber = 1;
            }
            var deal = _unitOfWork.dealRepo.geBySlug(dealSlug);
            var attrOption = new List<SpecificationAttributeOption>();

            foreach (var i in specs)
            {
                var option = await _unitOfWork.SpecificationAttributes.GetAttrOptionByID(i);
                if (option != null)
                {
                    attrOption.Add(option);
                }
            }

            //prepare model
            List<int> discountIds=new List<int>();
            foreach (var id in deal.DealDiscounts)
            {
                discountIds.Add(id.discountID);
            }
            var disc = await _discountModelFactory.PrepareDiscountSProductListModelAsync(discountIds, pageSize, pageNumber);
            var metadata = new
            {
                deal,
                disc,
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
