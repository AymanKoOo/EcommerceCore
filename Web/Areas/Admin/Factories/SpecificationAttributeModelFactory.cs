using AutoMapper;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Areas.Admin.ViewModels.Catalog;

namespace Web.Areas.Admin.Factories
{
    public class SpecificationAttributeModelFactory : ISpecificationAttributeModelFactory
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public SpecificationAttributeModelFactory(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<ASpecificationAttributeModel> PrepareSpecificationAttributeModel()
        {
            var specificAtrGroups = await unitOfWork.SpecificationAttributes.GetAllSpecificationAttributeGroup();

            var model = new ASpecificationAttributeModel();

            model.SpecificationAttributeGroup =  specificAtrGroups;
            return model;
        }
        public async Task<ASpecificationAttributeOptionModel> PrepareSpecificationAttributeOptionModel()
        {
            var Attr = await unitOfWork.SpecificationAttributes.GetAllSpecificationAttributes();

            var model = new ASpecificationAttributeOptionModel();

            model.specificationAttributes = Attr;
            return model;
        }
    }
}
