using Core.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Interfaces
{
    public interface ICategoryRepo:IGenericRepo<Category>
    {
        List<Category> GetCategories();
        Product GetCategory(string categoryName);
        void AddCategory (Category category);
        void EditCategory(Category category);
        void DeleteCategory(Category category);

    }
}
