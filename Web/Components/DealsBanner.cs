using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Components
{
    public class DealsBanner:ViewComponent
    {

        private readonly IUnitOfWork unitOfWork;

        public DealsBanner(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var deals = await unitOfWork.dealRepo.GetForbanner();
            return View(deals);
        }
    }
}
