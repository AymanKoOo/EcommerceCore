﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Core.Entites;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Web.DTOs;

namespace Web.Controllers
{
    [Route("/category")]
    public class CategoryController : Controller
    {
        private IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoryController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        [Route("AddCategory")]
        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }

        [Route("AddCategory")]
        [HttpPost]
        public IActionResult AddCategory(CategoryDTO categoryDTO)
        {
            var result = _mapper.Map<Category>(categoryDTO);
            _unitOfWork.Category.Add(result);
            _unitOfWork.Save();
            return View();
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

        [HttpPost]
        [Route("index")]
        public IActionResult Index(int categoryID)
        {
            var products = _mapper.Map<List<ProductDTO>>(_unitOfWork.Product.GetProductsByCatgory(categoryID));

            var indexdto = new IndexDTO
            {
                productDTOs = products
            };

            return Ok(indexdto);
        }

    }
}