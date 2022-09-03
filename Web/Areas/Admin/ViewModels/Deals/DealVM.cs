using Core.Entites.Catalog;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Areas.Admin.ViewModels.Deals
{
    public class DealVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }
        public bool ShowOnBigBanner { get; set; }
        public bool ShowOnSmallBanner { get; set; }
        public IFormFile Picture { get; set; }
        public virtual ICollection<DealDiscount> DealDiscounts { get; set; }
    }
}
