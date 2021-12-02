using AutoMapper;
using Core.Entites;
using Infrastructure.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Areas.Admin.ViewModels;
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

            CreateMap<ProductModel, Product>();
            CreateMap<Product, ProductModel>();


            CreateMap<Category, CategoryVM>();
            CreateMap<CategoryVM, Category>();
        }
    }
}
