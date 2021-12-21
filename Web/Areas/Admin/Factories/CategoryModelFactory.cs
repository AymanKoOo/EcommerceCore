﻿using AutoMapper;
using Core.Entites;
using Core.Interfaces;
using Infrastructure.Services;
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
        private readonly IPriceCalculationService priceCalculation;
        private readonly IProductModelFactory productModelFactory;

        public CategoryModelFactory(IUnitOfWork unitOfWork, IMapper mapper, IPriceCalculationService priceCalculation, IProductModelFactory productModelFactory)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.priceCalculation = priceCalculation;
            this.productModelFactory = productModelFactory;
        }

        public async Task<ACategoryModel> PrepareCategoryModelAsync(ACategoryModel model,Category category, int pageSize = 5, int pageNumber = 1)
        {
            if (category != null)
            {
                model = mapper.Map<ACategoryModel>(category);
                //assign subcategories
                model.SubCategories = await unitOfWork.Category.GetSubCategory(category.Id);

                //assign category products
                model.ProductsList = await productModelFactory.PrepareProductByCategoryListModelAsync(category.Id,pageSize,pageNumber);
            }

            var categories = await unitOfWork.Category.GetAllCategoriesAsync();
            //assign all categories
            model.AvailableCategories = categories;
            return model;
        }
    }
}
