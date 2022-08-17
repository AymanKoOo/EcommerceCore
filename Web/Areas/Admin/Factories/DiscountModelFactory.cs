using AutoMapper;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Areas.Admin.ViewModels.Categories;
using Web.Areas.Admin.ViewModels.Discounts;
using Web.Services;

namespace Web.Areas.Admin.Factories
{
    public class DiscountModelFactory : IDiscountModelFactory
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public DiscountModelFactory(IUnitOfWork unitOfWork,IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public virtual async Task<DiscountProductListModel> PrepareDiscountProductListModelAsync(int discountid, int pageSize, int pageNumber)
        {

            var discountProducts = unitOfWork.Product.GetProductsWithAppliedDiscountAsync(discountid, pageSize, pageNumber);

            //var discountProductModels = mapper.Map<DiscountProductModel>(discountProducts.postsData);
           
            var model = new DiscountProductListModel().PrepareToGrid(discountProducts, () =>
            {
                //fill in model values from the entity
                return discountProducts.Data.Select(product =>
                {
                    var discountProductModel = mapper.Map<DiscountProductModel>(product);
                    discountProductModel.ProductId = product.Id;
                    discountProductModel.ProductName = product.Name;
                    return discountProductModel;
                });
            });
            //jquery create table gets products view it 
            //button add to dicount new form all check boxes will be added 
            //000000000000000000000000000000000000000000000000000
            //Home page show alll products with category old price new price show dicount

            //
            return model;
        }

        public virtual async Task<DiscountCategoryListModel> PrepareDiscountCategoryListModelAsync(int discountid, int pageSize, int pageNumber)
        {

            var discountCategories = unitOfWork.Category.GetAllCategoriesWithAppliedDiscountList(discountid, pageSize, pageNumber);

            //var discountProductModels = mapper.Map<DiscountProductModel>(discountProducts.postsData);

            var model = new DiscountCategoryListModel().PrepareToGrid(discountCategories, () =>
            {
                //fill in model values from the entity
                return discountCategories.Data.Select(category =>
                {
                    var discountCategoryModel = mapper.Map<DiscountCategoryModel>(category);
                    discountCategoryModel.Id = category.Id;
                    discountCategoryModel.Name = category.Name;
                    return discountCategoryModel;
                });
            });
            //jquery create table gets products view it 
            //button add to dicount new form all check boxes will be added 
            //000000000000000000000000000000000000000000000000000
            //Home page show alll products with category old price new price show dicount

            //
            return model;
        }


    }
}
