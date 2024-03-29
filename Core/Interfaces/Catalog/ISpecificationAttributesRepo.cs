﻿using AyyBlog.ViewModel;
using Core.Entites;
using Core.Entites.Catalog;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Catalog
{
    public interface ISpecificationAttributesRepo : IGenericRepo<SpecificationAttribute>
    {
        void AddSpecificationAttributeGroup(SpecificationAttributeGroup model);
        Task<IEnumerable<SpecificationAttributeGroup>> GetAllSpecificationAttributeGroup();
        Task CreateSpecificationAttribute(SpecificationAttribute model);
        Task CreateSpecificationAttributeOption(SpecificationAttributeOption model);
        Task<IEnumerable<SpecificationAttributeOption>> GetAllSpecificationAttributeOption();
        Task<IEnumerable<SpecificationAttribute>> GetAllSpecificationAttributes();
        //Task<IEnumerable<ASpecificationFilterModel>> GetAttributesByCategory(int categoryId);
        Task<SpecificationAttributeOption> GetAttrOptionByName(string name);
        Task<SpecificationAttributeOption> GetAttrOptionByID(int id);
        Task<SpecificationAttribute> GetSpecAttrByID(int id);
        Task<SpecificationAttributeGroup> GetSpecAttrGroupByID(int id);
        List<SpecificationAttribute> GetCommonSpecAttrFromProducts(List<Product> products);
    }
}
