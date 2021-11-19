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
        AssignedToProducts = 1,
        /// <summary>
        /// Assigned to categories (all products in a category)
        /// </summary>
        AssignedToCategories = 2,
    }
}
