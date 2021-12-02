﻿using AutoMapper;
using Core.Entites;
using Core.Interfaces;
using Infrastructure.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Web.Areas.Admin.ViewModels.Categories;
namespace Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[Controller]")]
    public class CategoryController : Controller
    {

        readonly private IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment environment;
        private readonly IPictureService picture;

        public CategoryController(IUnitOfWork unitOfWork, IMapper mapper, IWebHostEnvironment environment, IPictureService picture)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            this.environment = environment;
            this.picture = picture;
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

            //categoryModel.ImageName = category.ImageName;
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
        public async Task<IActionResult> AddCategory(CategoryVM model)
        {
            //if (!ModelState.IsValid)
            //{
            //    return View(model);
            //}
            DateTime todaysDate = DateTime.Today; // returns today's date

            var picName = await picture.UploadPictureAsync(model.ImgCategory, environment.WebRootPath);

            var picObj = new Picture
            {
                MimeType = picName,
            };

            await _unitOfWork.picture.Add(picObj);
           
            var category = _mapper.Map<Category>(model);
            await _unitOfWork.Category.Add(category);

            _unitOfWork.Save();

            var pic = await _unitOfWork.picture.getPicByName(picName);

            var cat = await _unitOfWork.Category.GetCategory(model.Name);
            
            await _unitOfWork.Category.AddPicture(cat.Id, pic.Id);
          
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
