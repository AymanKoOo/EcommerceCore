using AyyBlog.ViewModel;
using Core.Entites;
using Core.Entites.Catalog;
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
        
        Task AddCategorySpecGroup(CategorySpecificationGroup model);

        Task<Category> GetCategory(string categoryName);
        Category GetCategoryByID(int categoryID);
        
                    Category GetCategoryByName(string name);

        Task AddPicture(int categoryID,int picID);
        Task<List<Category>> GetAllCategoriesAsync();
        Task<List<Category>> GetSubCategory(int CategoryId);
        PagedList<Category> GetAllCategoriesList(int pageSize, int pageNumber);
    }
}
