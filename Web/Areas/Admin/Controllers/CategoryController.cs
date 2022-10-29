using AutoMapper;
using Core.Entites;
using Core.Entites.Catalog;
using Core.Interfaces;
using Infrastructure.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Web.Areas.Admin.Factories;
using Web.Areas.Admin.ViewModels.Catalog;
using Web.Areas.Admin.ViewModels.Categories;
namespace Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[Controller]")]
    public class CategoryController : Controller
    {

        readonly private IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ISlugService slugService;
        private readonly ICategoryModelFactory categoryModelFactory;
        private readonly IWebHostEnvironment environment;
        private readonly IPictureService picture;

        public CategoryController(IUnitOfWork unitOfWork, IMapper mapper, ISlugService slugService,ICategoryModelFactory categoryModelFactory, IWebHostEnvironment environment, IPictureService picture)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            this.slugService = slugService;
            this.categoryModelFactory = categoryModelFactory;
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

            var ACategoryModel = _mapper.Map<ACategoryModel>(category);

            return View(ACategoryModel);
        }   

        [HttpPost("EditCategory")]
        public async Task<IActionResult> EditCategory(ACategoryModel model)
        {
            var categoryModel = _unitOfWork.Category.GetCategoryByID(model.Id);
            //
            var picName = await picture.UploadPictureAsync(model.ImgCategory, environment.WebRootPath);

            var picObj = new Picture
            {
                MimeType = picName,
            };
            await _unitOfWork.picture.Add(picObj);
            _unitOfWork.Save();

            //
            var pic = await _unitOfWork.picture.getPicByName(picName);

            await _unitOfWork.Category.AddPicture(categoryModel.Id, pic.Id);

            categoryModel.Name = model.Name;

            categoryModel.Description = model.Description;
            //mapping
            _unitOfWork.Category.Update(categoryModel);
            _unitOfWork.Save();
            return Redirect("/");
        }

        [HttpGet("AddCategory")]
        public async Task<IActionResult> AddCategory()
        {
            var model = await categoryModelFactory.PrepareCategoryModelAsync(new ACategoryModel(), null);
            return View(model);
        }

        [HttpPost("AddCategory")]
        public async Task<IActionResult> AddCategory(ACategoryModel model)
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

            //if parentcategoryid > 0
            //get the parent cateogry make parentID=-1 as a parent
            if (model.ParentCategoryId > 0)
            {
                var parentCategory = _unitOfWork.Category.GetCategoryByID(model.ParentCategoryId);
                parentCategory.HasSubCategories = true;
                _unitOfWork.Category.Update(parentCategory);
            }
            //
            var category = _mapper.Map<Category>(model);
            await _unitOfWork.Category.Add(category);

            //check slug is unique//

            string CategorySlug = slugService.createSlug(model.Name);

            string uniqueSlug = _unitOfWork.Category.MakeCategorySlugUnique(CategorySlug);

            category.slug = uniqueSlug;

            _unitOfWork.Save();

            var pic = await _unitOfWork.picture.getPicByName(picName);

            var cat = await _unitOfWork.Category.GetCategoryBySlug(uniqueSlug);
            
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

        [HttpGet("CategorySpecGroupAdd")]
        public async Task<IActionResult> CategorySpecGroupAdd(int categoryId)
        {
            var model = await categoryModelFactory.PrepareCategorySpecGroup();
            model.CategoryID = categoryId;
            return View(model);
        }

        [HttpPost("CategorySpecGroupAdd")]
        public IActionResult CategorySpecGroupAdd(ACategorySpecificationGroup model)
        {
            var categorySpecificationGroup = _mapper.Map<CategorySpecificationGroup>(model);
            _unitOfWork.Category.AddCategorySpecGroup(categorySpecificationGroup);
            _unitOfWork.Save();
            return Redirect("/");
        }
    }
}
