using AutoMapper;
using Core.Entites;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Areas.Admin.ViewModels.Catalog;

namespace Web.Areas.Admin.Factories
{
    public class CategoryModelFactory:ICategoryModelFactory
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public CategoryModelFactory(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<ACategoryModel> PrepareCategoryModelAsync(ACategoryModel model,Category category)
        {
            if (category != null)
            {
                model = mapper.Map<ACategoryModel>(category);
                //assign subcategories
                model.SubCategories = await unitOfWork.Category.GetSubCategory(category.Id);

                //assign category products
                model.Products = unitOfWork.Product.GetProductsByCatgory(category.Id);
            }

            var categories = await unitOfWork.Category.GetAllCategoriesAsync();
            //assign all categories
            model.AvailableCategories = categories;
            return model;
        }
    }
}

