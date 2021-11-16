using AutoMapper;
using Core.Entites;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[Controller]")]
    public class CategoryController : Controller
    {

        readonly private IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoryController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var categories = _unitOfWork.Category.GetAllCategories(); 
            return View(categories);
        }


        [HttpGet("EditCategory")]
        public IActionResult EditCategory(int categoryID)
        {
            var category = _unitOfWork.Category.GetCategoryByID(categoryID);
            return View(category);
        }   

        [HttpPost("EditCategory")]
        public IActionResult EditCategory(Category category)
        {
            var categoryModel = _unitOfWork.Category.GetCategoryByID(category.Id);
            categoryModel.ImageName = category.ImageName;
            categoryModel.Name = category.Name;
            categoryModel.Description = category.Description;
            //mapping
            _unitOfWork.Category.Update(categoryModel);
            _unitOfWork.Save();
            return Redirect("/");
        }

        [HttpGet("AddCategory")]
        public IActionResult AddCategory()
        {
            return View();
        }
        [HttpPost("AddCategory")]
        public IActionResult AddCategory(Category category)
        {
            _unitOfWork.Category.Add(category);
            _unitOfWork.Save();
            return Redirect("/");
        }

        [HttpGet("DeleteCategory")]
        public IActionResult DeleteCategory(int categoryID)
        {
             var category = _unitOfWork.Category.GetCategoryByID(categoryID);
            _unitOfWork.Category.Delete(category);
            _unitOfWork.Save();
            return Redirect("/");
        }
    }
}
