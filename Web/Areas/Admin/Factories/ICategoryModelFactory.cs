using Core.Entites;
using Core.Entites.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Areas.Admin.ViewModels.Catalog;
using Web.Areas.Admin.ViewModels.Categories;

namespace Web.Areas.Admin.Factories
{
    public interface ICategoryModelFactory
    {
        public Task<CategoryListModel> PrepareCategoryNODiscountListModelAsync(int pageSize, int pageNumber);
        public Task<ACategorySpecificationGroup> PrepareCategorySpecGroup();
        public Task<ACategoryModel> PrepareCategoryModelAsync(ACategoryModel model, Category category, List<SpecificationAttributeOption> filterSearch = null, int OrderFilter = 0, int pageSize = 5, int pageNumber = 1);
    }
}
