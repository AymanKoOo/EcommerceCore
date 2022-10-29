using AutoMapper;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Components
{
    public class SideBar:ViewComponent
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public SideBar(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categories =  await unitOfWork.Category.GetAllCategoriesHome();
            return View(categories);
        }
    }
}
