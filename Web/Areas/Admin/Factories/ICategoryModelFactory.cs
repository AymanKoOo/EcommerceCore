using Core.Entites;
using Core.Entites.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Areas.Admin.ViewModels.Catalog;

namespace Web.Areas.Admin.Factories
{
    public interface ICategoryModelFactory
    {
        public Task<ACategorySpecificationGroup> PrepareCategorySpecGroup();
        public Task<ACategoryModel> PrepareCategoryModelAsync(ACategoryModel model, Category category, SpecificationAttributeOption filterSearch = null, int OrderFilter = 0, int pageSize = 5, int pageNumber = 1);
    }
}
