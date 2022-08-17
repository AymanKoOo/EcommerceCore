using AutoMapper;
using Core.Entites;
using Core.Entites.Catalog;
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
using Web.ViewModels.Products;

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

            CreateMap<SpecificationAttribute, ASpecificationAttributeModel>();
            CreateMap<ASpecificationAttributeModel, SpecificationAttribute>();

            CreateMap<SpecificationAttributeOption, ASpecificationAttributeOptionModel>();
            CreateMap<ASpecificationAttributeOptionModel, SpecificationAttributeOption>();

            CreateMap<AProductAttributeModel, ProductAttribute>();
            CreateMap<ProductAttribute, AProductAttributeModel>();

            CreateMap<ProductAttributeOption, AProductAttributeOptionModel>();
            CreateMap<AProductAttributeOptionModel, ProductAttributeOption>();


            CreateMap<ASpecificationAttributeOptionModel, SpecificationAttributeOption>();

            
            CreateMap<ProductSpecificationAttribute, AProductSpecificationOption>();
            CreateMap<AProductSpecificationOption, ProductSpecificationAttribute>();


            CreateMap<CategorySpecificationGroup, ACategorySpecificationGroup>();
            CreateMap<ACategorySpecificationGroup, CategorySpecificationGroup>();

            CreateMap<ProductModel, ProductsVM>();
            CreateMap<ProductsVM, ProductModel>();

            CreateMap<ProductModel, ProductsVM>()
              .ForMember
               (x => x.name,
               map => map.MapFrom(source => source.Name))

               .ForMember
               (x => x.OldPrice,
               map => map.MapFrom(source => source.OldPrice))
               .ForMember

               (x => x.picture,
               map => map.MapFrom(source => source.Picture))

             .ForMember
               (e => e.Price,
               map => map.MapFrom(source => source.Price))

             .ForMember
               (e => e.HasDiscountsApplied,
               map => map.MapFrom(source => source.HasDiscountsApplied));

            ////CreateMap<ProductAttributeOptionsMapping, ProductAttributeOption>();
            //CreateMap<ProductAttributeOption, ProductAttributeOptionsMapping>();

           
            //CreateMap<AProductAttributeCreate, ProductAttributeOptionsMapping>();
            //CreateMap<ProductAttributeOptionsMapping, AProductAttributeCreate>();

            CreateMap<AProductAttributeCreate, ProductAttributeMapping>();
            CreateMap<ProductAttributeMapping, AProductAttributeCreate>();

            CreateMap<ProductAttributeMapping, ProductAttributeOption>();
            CreateMap<ProductAttributeOption, ProductAttributeMapping>();

            CreateMap<ProductAttributeOption, AProductAttrMappingOption>()
                .ForMember
               (x => x.ProductMappingId,
               map => map.MapFrom(source => source.ProductAttributeMappingId));

            CreateMap<AProductAttrMappingOption, ProductAttributeOption>()
                   .ForMember
               (x => x.ProductAttributeMappingId,
               map => map.MapFrom(source => source.ProductMappingId));

            CreateMap<ProductAttributeMapping, AProductAttributeAdd>();
            CreateMap<AProductAttributeAdd, ProductAttributeMapping>();


            CreateMap<Discount, DiscountDTO>();
            CreateMap<DiscountDTO, Discount>();

            CreateMap<CategoryVM, Category>();
            CreateMap<Category, CategoryVM>();

            CreateMap<DiscountCategoryModel, Category>();
            CreateMap<Category, DiscountCategoryModel>();

        }
    }
}
