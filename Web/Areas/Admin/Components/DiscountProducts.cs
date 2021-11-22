using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Areas.Admin.Components
{
    public class DiscountProducts:ViewComponent
    {
        private readonly IUnitOfWork unitOfWork;

        public DiscountProducts(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        //public async Task<IViewComponentResult> InvokeAsync()
        //{
        //    var model = await unitOfWork
        //    if (!model.Any())
        //        return Content("");

        //    return View(model);
        //}
    }
}
