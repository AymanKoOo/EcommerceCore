﻿using AutoMapper;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Areas.Admin.ViewModels.Catalog;

namespace Web.Areas.Admin.Factories
{
    public class ProductAttributeModelFactory : IProductAttributeModelFactory
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public ProductAttributeModelFactory(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

      

        public Task<AProductAttributeModel> PrepareProductAttributeModel()
        {
            throw new NotImplementedException();
        }

        //public Task<AProductAttributeModel> PrepareProductAttributeModel()
        //{
        //    //var specificAtrGroups = await unitOfWork.SpecificationAttributes.GetAllSpecificationAttributeGroup();

        //    //var model = new ASpecificationAttributeModel();

        //    //model.SpecificationAttributeGroup = specificAtrGroups;
        //    //return model;
        //}

        public async Task<AProductAttributeOptionModel> PrepareProductAttributeOptionModel()
        {
            var Attr = await unitOfWork.productAttributes.GetAllProductAttributes();

            var model = new AProductAttributeOptionModel();

            model.productAttributes = Attr;
            return model;
        }
        public async Task<AProductAttributeCreate> PrepareProductAttributeAdd()
        {
            var model = new AProductAttributeCreate();
            var attrOptions = await unitOfWork.productAttributes.GetAllProductAttributeOption();
            var attr = await unitOfWork.productAttributes.GetAllProductAttributes();

            model.productAttributes = attr;
            model.productAttributeOptions = attrOptions;

            return model;
        }
    }
}
