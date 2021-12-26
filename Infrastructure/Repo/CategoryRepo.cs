using Core.Entites;
using Core.Interfaces;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Core.Entites.Catalog;
using AyyBlog.ViewModel;

namespace Infrastructure.Repo
{
    public class CategoryRepo:GenericRepo<Category>,ICategoryRepo
    {
        private readonly DataContext _dbcontext;
        public CategoryRepo(DataContext dbcontext) : base(dbcontext)
        {
            this._dbcontext = dbcontext;
        }

        public void AddCategory(Category category)
        {
            _dbcontext.Categories.Add(category);
        }

        public List<Category> GetAllCategories()
        {
            return (from cat in _dbcontext.Categories
                   select cat).Include(x=>x.categoryPictures).ThenInclude(e=>e.picture).ToList();
        }
        public async Task<List<Category>> GetAllCategoriesAsync()
        {
            return await (from cat in _dbcontext.Categories
                    select cat).Include(x => x.categoryPictures).ThenInclude(e => e.picture).ToListAsync();
        }

        public PagedList<Category> GetAllCategoriesList(int pageSize, int pageNumber)
        {
            var category =  (from cat in _dbcontext.Categories
                                  select cat).Include(x => x.categoryPictures).ThenInclude(e => e.picture);

            return PagedList<Category>.ToPagedList(category,
            pageNumber,
            pageSize);
        }
        public async Task<IEnumerable<Category>> GetAllCategoriesHome()
        {
            return await _dbcontext.Categories.Include(x => x.categoryPictures).ThenInclude(e => e.picture).ToListAsync();
        }

        public Category GetCategoryByID(int id)
        {
            return _dbcontext.Categories.Where(e=>e.Id==id).Include(x=>x.CategorySpecificationGroups).ThenInclude(r=>r.specificationAttributeGroup)
                .ThenInclude(q=>q.SpecificationAttribute).ThenInclude(q => q.specificationAttributeOptions).FirstOrDefault();
        }

        public async Task<List<Category>> GetSubCategory(int CategoryId)
        {
            return await _dbcontext.Categories.Where(x => x.ParentCategoryId == CategoryId).ToListAsync();
        }

        public async Task<Category> GetCategory(string categoryName)
        {
            return  await  _dbcontext.Categories.FirstOrDefaultAsync(m => m.Name == categoryName);
        }

        public async Task AddPicture(int categoryID, int picID)
        {
            var model = new CategoryPicture
            {
                categoryID = categoryID,
                PictureId = picID
            };
             await  _dbcontext.categoryPictures.AddAsync(model);
        }

        public async Task AddCategorySpecGroup(CategorySpecificationGroup model)
        {
            await _dbcontext.categorySpecificationGroups.AddAsync(model);
        }

        public Category GetCategoryByName(string name)
        {
            return _dbcontext.Categories.Where(e => e.Name == name).Include(x => x.CategorySpecificationGroups).ThenInclude(r => r.specificationAttributeGroup)
               .ThenInclude(q => q.SpecificationAttribute).ThenInclude(q => q.specificationAttributeOptions).FirstOrDefault();

        }
        //public void AddCategoryPic(int categoryID,string picPath)
        //{

        //    var pic = new Picture
        //    {
        //       MimeType = picPath
        //    };

        //    _dbcontext.pictures.Add(pic);

        //    var catpr = new CategoryPicture()
        //    {
        //        categoryID = categoryID,

        //    }
        //    _dbcontext.categoryPictures.Add();
        //}
    }
}
