using Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Areas.Admin.ViewModels
{
    public class EditProductVM
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageFile { get; set; }
        public decimal UnitPrice { get; set; }

        // n-1 relationships
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public  List<Category> categories { get; set; }
    }
}
