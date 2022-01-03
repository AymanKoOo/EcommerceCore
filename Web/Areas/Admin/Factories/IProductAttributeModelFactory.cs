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
        public Task<AProductAttributeCreate> PrepareProductAttributeAdd(int productID);
    }
}
