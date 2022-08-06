using AutoMapper;
using Core.Entites;
using Core.Entites.Catalog;
using Core.Interfaces;
using Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Areas.Admin.ViewModels.Catalog;
using Web.Areas.Admin.ViewModels.Categories;
using Web.Services;

namespace Web.Areas.Admin.Factories
{
    public class CategoryModelFactory:ICategoryModelFactory
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IPriceCalculationService priceCalculation;
        private readonly IProductModelFactory productModelFactory;

        public CategoryModelFactory(IUnitOfWork unitOfWork, IMapper mapper, IPriceCalculationService priceCalculation, IProductModelFactory productModelFactory)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.priceCalculation = priceCalculation;
            this.productModelFactory = productModelFactory;
        }

        public async Task<ACategoryModel> PrepareCategoryModelAsync(ACategoryModel model, Category category,List<SpecificationAttributeOption> filterSpec = null, int OrderFilter=0, int pageSize = 5, int pageNumber = 1)
        {
            if (category != null)
            {
                model = mapper.Map<ACategoryModel>(category);
                //assign subcategories
                model.SubCategories = await unitOfWork.Category.GetSubCategory(category.Id);

                //assign category products
                model.ProductsList = await productModelFactory.PrepareProductByCategoryListModelAsync(category.Id,pageSize,pageNumber, filterSpec, OrderFilter);

                model.CategoryAttributes = category.CategorySpecificationGroups;
            }

            var categories = await unitOfWork.Category.GetAllCategoriesAsync();
            //assign all categories
            model.AvailableCategories = categories;
            return model;
        }


        public virtual async Task<CategoryListModel> PrepareCategoryNODiscountListModelAsync(int pageSize, int pageNumber)
        {
            var categories = unitOfWork.Category.GetAllCategoriesWithoutDiscountList(pageSize, pageNumber);
            var model = new CategoryListModel().PrepareToGrid(categories, () =>
            {
                //fill in model values from the entity
                return categories.Data.Select(category =>
                {
                    var discountCategoryModel = mapper.Map<CategoryVM>(category);
                    return discountCategoryModel;
                });
            });
            return model;
        }

        public async Task<ACategorySpecificationGroup> PrepareCategorySpecGroup()
        {
            var model = new ACategorySpecificationGroup();
            var attrGr = await unitOfWork.SpecificationAttributes.GetAllSpecificationAttributeGroup();
            model.specificationAttributeGroups = attrGr;
            return model;
        }
    }
}

