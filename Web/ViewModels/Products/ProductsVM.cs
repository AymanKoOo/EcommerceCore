using Core.Entites.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.ViewModels.Products
{
    public class ProductsVM
    {

        public string name { get; set; }
        public string picture { get; set; }
        public decimal OldPrice { get; set; }
        public decimal Price { get; set; }
        public bool HasDiscountsApplied { get; set; }
 
    }
}
