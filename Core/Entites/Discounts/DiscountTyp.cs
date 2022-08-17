using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entites.Discounts
{
    public enum DiscountTyp
    {
        /// <summary>
        /// Assigned to order total 
        /// </summary>       
        AssignedToCategories = 1,

        AssignedToProducts = 2,
        /// <summary>
        /// Assigned to categories (all products in a category)
        /// </summary>
    }
}
