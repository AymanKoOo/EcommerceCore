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
        public async Task<IEnumerable<Category>> GetAllCategoriesHome()
        {
            return await _dbcontext.Categories.Include(x => x.categoryPictures).ThenInclude(e => e.picture).ToListAsync();
        }

        public Category GetCategoryByID(int id)
        {
            return _dbcontext.Categories.FirstOrDefault(m => m.Id == id);
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
