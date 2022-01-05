using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Areas.Admin.ViewModels.Catalog;

namespace Web.Areas.Admin.Factories
{
    public interface IProductAttributeModelFactory
    {
        public Task<AProductAttributeModel> PrepareProductAttributeModel();
        public Task<AProductAttributeOptionModel> PrepareProductAttributeOptionModel();
        public Task<AProductAttributeAdd> PrepareProductAttributeAdd(int productID);
        public Task<AProductAttrMappingOption> ProductAttributeMappingOptionModel(AProductAttrMappingOption model, int PAMappingID);

    }
}
