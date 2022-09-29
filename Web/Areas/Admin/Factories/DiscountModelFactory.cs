using AutoMapper;
using AyyBlog.ViewModel;
using Core.Entites;
using Core.Entites.Catalog;
using Core.Interfaces;
using Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Areas.Admin.ViewModels.Categories;
using Web.Areas.Admin.ViewModels.Discounts;
using Web.Areas.Admin.ViewModels.Products;
using Web.Services;

namespace Web.Areas.Admin.Factories
{
    public class DiscountModelFactory : IDiscountModelFactory
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IPriceCalculationService priceCalculation;

        public DiscountModelFactory(IUnitOfWork unitOfWork,IMapper mapper, IPriceCalculationService priceCalculation)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.priceCalculation = priceCalculation;
        }
      
        public virtual async Task<ProductListModel> PrepareDiscountProductListModelAsync(int discountid, int pageSize, int pageNumber, int OrderFilter = 0, List<SpecificationAttributeOption> filterSpec = null)
        {

            var discountProducts = unitOfWork.Product.GetProductsWithAppliedDiscountAsync(discountid, filterSpec, pageSize,pageNumber,OrderFilter);

            var AlldiscountProducts = unitOfWork.Product.GetAllProductsWithAppliedDiscountAsync(discountid);

            var TspecifcationAtrributes = unitOfWork.SpecificationAttributes.GetCommonSpecAttrFromProducts(discountProducts);

            var model = new ProductListModel();
            foreach (var pr in discountProducts)
            {
                var pricingObj = await priceCalculation.GetFinalPriceAsync(pr);
                pr.OldPrice = pricingObj.priceWithoutDiscounts;
                pr.Price = pricingObj.finalPrice;
            }
            if (discountProducts.Count > 0)
            {

                model = new ProductListModel().PrepareToGrid(discountProducts, () =>
                {

                    //fill in model values from the entity
                    return discountProducts.Data.Select(product =>
                    {
                        var discountProductModel = mapper.Map<ProductModel>(product);

                        discountProductModel.Id = product.Id;
                        discountProductModel.Name = product.Name;
                        discountProductModel.Picture = product.productPictures[0].picture.MimeType;
                        discountProductModel.OldPrice = product.OldPrice;
                        discountProductModel.Price = product.Price;
                        discountProductModel.HasDiscountsApplied = product.HasDiscountsApplied;
                        return discountProductModel;
                    });
                });
                model.SpecificationAttributes = TspecifcationAtrributes;

            }

            else
            {
                model = new ProductListModel().PrepareToGrid(discountProducts, () =>
                {
                    //fill in model values from the entity
                    return discountProducts.Data.Select(product =>
                    {
                        var discountProductModel = mapper.Map<ProductModel>(product);
                        return discountProductModel;
                    });
                });
            }

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
        public virtual async Task<ProductListModel> PrepareDiscountSProductListModelAsync(List<int> discountid, int pageSize, int pageNumber, int OrderFilter = 0, List<SpecificationAttributeOption> filterSpec = null)
        {
            var discountProducts = unitOfWork.Product.GetProductsWithAppliedDiscountSAsync(discountid,filterSpec, pageSize, pageNumber,OrderFilter);

            var AlldiscountProducts = unitOfWork.Product.GetAllProductsWithAppliedDiscountSAsync(discountid);

            var TspecifcationAtrributes = unitOfWork.SpecificationAttributes.GetCommonSpecAttrFromProducts(AlldiscountProducts);

            //var discountProductModels = mapper.Map<DiscountProductModel>(discountProducts.postsData);

            var model = new ProductListModel();
            foreach (var pr in discountProducts)
            {
                var pricingObj = await priceCalculation.GetFinalPriceAsync(pr);
                pr.OldPrice = pricingObj.priceWithoutDiscounts;
                pr.Price = pricingObj.finalPrice;
            }
            if (discountProducts.Count > 0)
            {

                model = new ProductListModel().PrepareToGrid(discountProducts, () =>
                {
                    //fill in model values from the entity
                    return discountProducts.Data.Select(product =>
                    {
                        var discountProductModel = mapper.Map<ProductModel>(product);
                        discountProductModel.Id = product.Id;
                        discountProductModel.Name = product.Name;
                        discountProductModel.Picture = product.productPictures[0].picture.MimeType;
                        discountProductModel.OldPrice = product.OldPrice;
                        discountProductModel.Price = product.Price;
                        discountProductModel.HasDiscountsApplied = product.HasDiscountsApplied;
                        return discountProductModel;
                    });
                });
                model.SpecificationAttributes = TspecifcationAtrributes;

            }

            else
            {
                model = new ProductListModel().PrepareToGrid(discountProducts, () =>
                {
                    //fill in model values from the entity
                    return discountProducts.Data.Select(product =>
                    {
                        var discountProductModel = mapper.Map<ProductModel>(product);
                        return discountProductModel;
                    });
                });
            }


            //var model = new DiscountProductListModel().PrepareToGrid(discountProducts, () =>
            //{
            //    //fill in model values from the entity
            //    return discountProducts.Data.Select(product =>
            //    {
            //        var discountProductModel = mapper.Map<DiscountProductModel>(product);
            //        discountProductModel.ProductId = product.Id;
            //        discountProductModel.ProductName = product.Name;
            //        discountProductModel.picture = product.productPictures[0].picture.MimeType;
            //        discountProductModel.OldPrice = pricingObj.priceWithoutDiscounts;
            //        discountProductModel.Price = pricingObj.finalPrice;
            //        discountProductModel.HasDiscountsApplied = product.HasDiscountsApplied;
            //        return discountProductModel;
            //    });
            //});
            //jquery create table gets products view it 
            //button add to dicount new form all check boxes will be added 
            //000000000000000000000000000000000000000000000000000
            //Home page show alll products with category old price new price show dicount

            //
            return model;
        }
    }
}
