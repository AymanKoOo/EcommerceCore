using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Core.Entites;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Web.Areas.Admin.Factories;
using Web.Areas.Admin.ViewModels.Catalog;
using Web.DTOs;

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

        [HttpGet("{id}")]
        public async Task<IActionResult> Index(int id,int pageSize = 1, int pageNumber = 1)
        {
            //var products = _mapper.Map<List<ProductDTO>>(_unitOfWork.Product.GetAllProducts());
            //var categories = _mapper.Map<List<CategoryDTO>>(_unitOfWork.Category.GetAllCategories());

            //var indexdto = new IndexDTO
            //{
            //    productDTOs = products,
            //    categoryDTOs = categories
            //};
            var category = _unitOfWork.Category.GetCategoryByID(id);

            //prepare model
            var categoryModel = await categoryModelFactory.PrepareCategoryModelAsync(new ACategoryModel(),category,pageSize,pageNumber);

            return View(categoryModel);
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