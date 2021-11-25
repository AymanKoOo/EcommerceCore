using AutoMapper;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Areas.Admin.ViewModels.Products;
using Web.Services;

namespace Web.Areas.Admin.Factories
{
    public class ProductModelFactory : IProductModelFactory
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public ProductModelFactory(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
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

    }
}
