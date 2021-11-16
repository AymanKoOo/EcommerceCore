using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Core.Entites;
using Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web.DTOs;

namespace Web.Controllers { 

    public class HomeController : Controller
    {

        private IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public HomeController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var products = _mapper.Map<List<ProductDTO>>(_unitOfWork.Product.GetAllProducts());
            var categories = _mapper.Map<List<CategoryDTO>>(_unitOfWork.Category.GetAllCategories());


            var indexdto = new IndexDTO
            {
                productDTOs = products,
                categoryDTOs = categories
            };

            return View(indexdto);
        }

    }

    ///https://github.com/aspnetrun/run-aspnetcore-realworld/tree/master/src/AspnetRun.Web
}