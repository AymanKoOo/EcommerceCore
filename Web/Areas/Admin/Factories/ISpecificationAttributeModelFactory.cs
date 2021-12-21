using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Areas.Admin.ViewModels.Catalog;

namespace Web.Areas.Admin.Factories
{
    public interface ISpecificationAttributeModelFactory
    {
        public Task<ASpecificationAttributeModel> PrepareSpecificationAttributeModel();
        public Task<ASpecificationAttributeOptionModel> PrepareSpecificationAttributeOptionModel();
    }
}
