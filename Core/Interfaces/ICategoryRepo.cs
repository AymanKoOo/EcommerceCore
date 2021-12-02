using Core.Entites;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface ICategoryRepo:IGenericRepo<Category>
    {
        List<Category> GetAllCategories();
        Task<IEnumerable<Category>> GetAllCategoriesHome();

         Task<Category> GetCategory(string categoryName);
        Category GetCategoryByID(int categoryID);
        Task AddPicture(int categoryID,int picID);
    }
}
