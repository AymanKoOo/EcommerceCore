using AutoMapper;
using Core.Interfaces;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.DTOs;

namespace Web.Components
{
    public class HomeProducts : ViewComponent
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IPriceCalculationService priceCalculation;

        public HomeProducts(IUnitOfWork unitOfWork,IMapper mapper, IPriceCalculationService priceCalculation) 
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.priceCalculation = priceCalculation;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var products = await unitOfWork.Product.GetAllProducts();

            foreach(var product in products)
            {
               var pricingObj = await priceCalculation.GetFinalPriceAsync(product);
                product.OldPrice = pricingObj.priceWithoutDiscounts;
                product.Price = pricingObj.finalPrice;
            }

            var finalProducts =  mapper.Map<List<ProductDTO>>(products);
            return View(finalProducts);
        }
    }
}
