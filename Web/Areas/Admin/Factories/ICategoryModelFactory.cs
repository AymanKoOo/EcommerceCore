using Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Areas.Admin.ViewModels.Catalog;

namespace Web.Areas.Admin.Factories
{
    public interface ICategoryModelFactory
    {
        public Task<ACategoryModel> PrepareCategoryModelAsync(ACategoryModel model, Category category);
    }
}
