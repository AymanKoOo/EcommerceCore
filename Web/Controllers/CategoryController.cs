﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Core.Entites;
using Core.Entites.Catalog;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Web.Areas.Admin.Factories;
using Web.Areas.Admin.ViewModels.Catalog;
using Web.Areas.Admin.ViewModels.Products;
using Web.DTOs;
using Web.ViewModels.Products;

namespace Web.Controllers
{
    [Route("/category")]
    public class CategoryController : Controller
    {
        private IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ICategoryModelFactory categoryModelFactory;

        public CategoryController(IUnitOfWork unitOfWork, IMapper mapper, ICategoryModelFactory categoryModelFactory)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            this.categoryModelFactory = categoryModelFactory;
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
        public async Task<IActionResult> Index(string cat, int pageSize = 2, int pageNumber = 1, int orderBy = 0, int[] specs = null)
        {
           
            //var products = _mapper.Map<List<ProductDTO>>(_unitOfWork.Product.GetAllProducts());
            //var categories = _mapper.Map<List<CategoryDTO>>(_unitOfWork.Category.GetAllCategories());

            //var indexdto = new IndexDTO
            //{
            //    productDTOs = products,
            //    categoryDTOs = categories
            //};
            //var category = _unitOfWork.Category.GetCategoryByID(id);
            var category = _unitOfWork.Category.GetCategoryByName(cat);
            if (category == null)
            {
                return View("choose Cat");
            }
            //var attrOption = await _unitOfWork.SpecificationAttributes.GetAttrOptionByName(filterSearch);
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
            var categoryModel = await categoryModelFactory.PrepareCategoryModelAsync(new ACategoryModel(), category, attrOption, orderBy, pageSize, pageNumber);

            return View(categoryModel);
        }


        [HttpGet("cat")]
        public async Task<IActionResult> FilterProducts(string cat, int pageSize = 2, int pageNumber = 1, int orderBy = 0, int[] specs = null)
        {
            if (pageNumber < 0)
            {
                pageNumber = 1;
            }
            var category = _unitOfWork.Category.GetCategoryByName(cat);
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
            var categoryModel = await categoryModelFactory.PrepareCategoryModelAsync(new ACategoryModel(), category, attrOption, orderBy, pageSize, pageNumber);
           
            var products = _mapper.Map<List<ProductsVM>>(categoryModel.ProductsList.Data);

            var metadata = new
            {      
                    products,
                    orderBy,
                    cat
                    ,specs,
                    categoryModel.ProductsList.TotalCount,
                    categoryModel.ProductsList.PageSize,
                    categoryModel.ProductsList.CurrentPage,
                    categoryModel.ProductsList.TotalPages,
                    categoryModel.ProductsList.HasNext,
                    categoryModel.ProductsList.HasPrevious
                };
                return Ok(metadata);
        }


        //[HttpPost]
        //[Route("index")]
        //public IActionResult Index(int categoryID,int s)
        //{
        //    var products = _mapper.Map<List<ProductDTO>>(_unitOfWork.Product.GetProductsByCatgory(categoryID));

        //    var indexdto = new IndexDTO
        //    {
        //        productDTOs = products
        //    };

        //    return Ok(indexdto);
        //}

    }
}