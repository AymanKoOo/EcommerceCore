using Core.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Interfaces
{
    public interface ICategoryRepo:IGenericRepo<Category>
    {
        List<Category> GetAllCategories();
        Product GetCategory(string categoryName);
        Category GetCategoryByID(int categoryID);

    }
}
