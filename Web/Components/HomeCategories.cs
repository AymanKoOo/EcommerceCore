using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Components
{
    public class HomeCategories : ViewComponent
    {
        private readonly IUnitOfWork unitOfWork;

        public HomeCategories(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categories = await unitOfWork.Category.GetAllCategoriesHome();
            return View(categories);
        }
    }
}
