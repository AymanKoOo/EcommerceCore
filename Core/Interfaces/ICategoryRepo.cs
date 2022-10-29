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
        Task<Category> GetCategoryBySlug(string slug);

        List<Category> GetAllCategories();
        Task<IEnumerable<Category>> GetAllCategoriesHome();
        Task<Category> GetCategory(int id);
        Task AddCategorySpecGroup(CategorySpecificationGroup model);
        Task<Category> GetCategory(string categoryName);
        Category GetCategoryByID(int categoryID);
        string MakeCategorySlugUnique(string Slug);
        Task<List<Category>> GetSubCategoryBySlug(string Slug);
        Task<List<Category>> GetParentCategories();
        Category GetCategoryByName(string name);

        Task AddPicture(int categoryID,int picID);
        Task<List<Category>> GetAllCategoriesAsync();
        Task<List<Category>> GetSubCategory(int CategoryId);
        PagedList<Category> GetAllCategoriesList(int pageSize, int pageNumber);
        PagedList<Category> GetAllCategoriesWithoutDiscountList(int pageSize, int pageNumber);
        Task EditPicture(Category categoryModel, Picture picObj);
        Task AddCategoryTODiscount(Category category, int discountID);

        PagedList<Category> GetAllCategoriesWithAppliedDiscountList(int discountId, int pageSize, int pageNumber);

    }
}
