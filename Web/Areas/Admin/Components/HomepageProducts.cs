using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Components
{
    public class HomepageProducts: ViewComponent
    {
        public HomepageProducts( )
        {
         
        }

        //public async Task<IViewComponentResult> InvokeAsync()
        //{
        //    var model = await _catalogModelFactory.PrepareHomepageCategoryModelsAsync();
        //    if (!model.Any())
        //        return Content("");

        //    return View(model);
        //}
    }
}
