using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Areas.Admin.Factories;

namespace Web.Areas.Admin.Components
{
    public class DiscountProducts:ViewComponent
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IDiscountModelFactory discountModelFactory;

        public DiscountProducts(IUnitOfWork unitOfWork,IDiscountModelFactory discountModelFactory) { 
      
            this.unitOfWork = unitOfWork;
            this.discountModelFactory = discountModelFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(int discountID, int pageSize, int pageNumber)
        {
            var products = await discountModelFactory.PrepareDiscountProductListModelAsync(discountID, pageSize, pageNumber);
            return View(products);
        }
    }
}
