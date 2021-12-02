using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Components
{
    public class DiscountBanner : ViewComponent
    {
        private readonly IUnitOfWork unitOfWork;

        public DiscountBanner(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var discount = await unitOfWork.discount.GetForbanner();
            return View(discount);
        }
    }
}
