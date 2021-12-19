using AutoMapper;
using Core.Entites;
using Infrastructure.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Areas.Admin.ViewModels;
using Web.Areas.Admin.ViewModels.Catalog;
using Web.Areas.Admin.ViewModels.Categories;
using Web.Areas.Admin.ViewModels.Discounts;
using Web.Areas.Admin.ViewModels.Products;
using Web.DTOs;

namespace Web.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDTO>();
            CreateMap<ProductDTO, Product>();
            CreateMap<CategoryDTO, Category>();
            CreateMap<Category, CategoryDTO>();
            
            CreateMap<ProductPageDTO, Product>();
            CreateMap<Product, ProductPageDTO>();

            CreateMap<ApplicationUser, CustomerDTO>();
            CreateMap<CustomerDTO, ApplicationUser>();

            CreateMap<DiscountProductListModel, Product>(); 
            CreateMap<DiscountProductModel, Product>();
            CreateMap<Product, DiscountProductModel>();

            CreateMap<List<ProductDTO>, Product>();
            CreateMap<ProductDTO, Product>();
            CreateMap<Product, ProductDTO>();

            CreateMap<Category, CategoryVM>();
            CreateMap<CategoryVM, Category>();

            CreateMap<ProductModel, Product>();
            CreateMap<Product, ProductModel>();

            CreateMap<AProductModel, Product>();
            CreateMap<Product, AProductModel>();

            CreateMap<ACategoryModel, Category>();
            CreateMap<Category, ACategoryModel>();

        }
    }
}
