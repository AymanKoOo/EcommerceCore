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
using Web.Areas.Admin.ViewModels.Products;
using Web.Services;

namespace Web.Areas.Admin.Factories
{
    public class ProductModelFactory : IProductModelFactory
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IPriceCalculationService priceCalculation;

        public ProductModelFactory(IUnitOfWork unitOfWork, IMapper mapper, IPriceCalculationService priceCalculation)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.priceCalculation = priceCalculation;
        }

        public virtual async Task<ProductListModel> PrepareProductListModelAsync(int pageSize, int pageNumber)
        {
            var products = unitOfWork.Product.GetAllProductsList(pageSize, pageNumber);

            var model = new ProductListModel().PrepareToGrid(products, () =>
            {
                //fill in model values from the entity
                return products.Data.Select(product =>
                {
                    var discountProductModel = mapper.Map<ProductModel>(product);
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

        public virtual async Task<ProductListModel> PrepareProductByCategoryListModelAsync(int categoryID,int pageSize, int pageNumber, SpecificationAttributeOption filterSpec,int OrderFilter)
        {
            var products = unitOfWork.Product.GetProductsByCatgoryList(categoryID,pageSize, pageNumber, filterSpec, OrderFilter);
            
            foreach (var product in products)
            {
                var pricingObj = await priceCalculation.GetFinalPriceAsync(product);
                product.OldPrice = pricingObj.priceWithoutDiscounts;
                product.Price = pricingObj.finalPrice;
            }
            var model = new ProductListModel().PrepareToGrid(products, () =>
            {
                //fill in model values from the entity
                return products.Data.Select(product =>
                {
                    var discountProductModel = mapper.Map<ProductModel>(product);
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

        public async Task<AProductModel> PrepareProductModelAsync(AProductModel model, Product product)
        {
            if (product != null)
            {
                //fill in model values from the entity
                if (model == null)
                {
                    model = mapper.Map<AProductModel>(product);
                }
            }
            //set default values for the new model
            if (product == null)
            {
                
            }
            
            //prepare model select categories
            var categories = await unitOfWork.Category.GetAllCategoriesAsync();
            model.categories = categories;

            return model;
        }

        public virtual async Task<ProductListModel> PrepareProductNODiscountListModelAsync(int pageSize, int pageNumber)
        {
            var products = unitOfWork.Product.GetAllProductsWithoutDiscountList(pageSize, pageNumber);

            var model = new ProductListModel().PrepareToGrid(products, () =>
            {
                //fill in model values from the entity
                return products.Data.Select(product =>
                {
                    var discountProductModel = mapper.Map<ProductModel>(product);
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

        public async Task<AProductSpecificationOption> PrepareProductSpecifcationAttr()
        {
            var model = new AProductSpecificationOption();
            var attrOptions = await unitOfWork.SpecificationAttributes.GetAllSpecificationAttributeOption();
            var attr = await unitOfWork.SpecificationAttributes.GetAllSpecificationAttributes();

            model.specificationAttributes = attr;
            model.specificationAttributeOptions = attrOptions;

            return model;
        }
    }
}
