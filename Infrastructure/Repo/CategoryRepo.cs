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
using Core.Entites.Discounts;

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
        public PagedList<Category> GetAllCategoriesWithoutDiscountList(int pageSize, int pageNumber)
        {
            var categories = _dbcontext.Categories.Where(x => x.HasDiscountsApplied == false);

            return PagedList<Category>.ToPagedList(categories,
            pageNumber,
            pageSize);
        }
        public PagedList<Category> GetAllCategoriesWithAppliedDiscountList(int discountId, int pageSize, int pageNumber)
        {
            var categories = _dbcontext.Categories.Where(x => x.HasDiscountsApplied);

            if (discountId >= 0)
                categories = from category in categories
                           join dpm in _dbcontext.discountCategories on category.Id equals dpm.CategoryId
                           where dpm.DiscountsId == discountId
                           select category;

            categories = categories.OrderBy(Category => Category.Name).ThenBy(Category => Category.Id);

            return PagedList<Category>.ToPagedList(categories,
            pageNumber,
            pageSize);
        }
        public async Task<IEnumerable<Category>> GetAllCategoriesHome()
        {
            return await _dbcontext.Categories.Where(q=>q.ParentCategoryId==0).Include(x => x.categoryPictures).ThenInclude(e => e.picture).ToListAsync();
        }

        public Category GetCategoryByID(int id)
        {
            return _dbcontext.Categories.Where(e=>e.Id==id).Include(x=>x.CategorySpecificationGroups).ThenInclude(r=>r.specificationAttributeGroup)
                .ThenInclude(q=>q.SpecificationAttribute).ThenInclude(q => q.specificationAttributeOptions).Include(x => x.categoryPictures).ThenInclude(r => r.picture).FirstOrDefault();
        }

        public async Task<List<Category>> GetSubCategory(int CategoryId)
        {
            return await _dbcontext.Categories.Where(x => x.ParentCategoryId == CategoryId).ToListAsync();
        }

        public async Task<Category> GetCategory(string categoryName)
        {
            return  await  _dbcontext.Categories.FirstOrDefaultAsync(m => m.Name == categoryName);
        }
        public async Task<Category> GetCategory(int id)
        {
            return await _dbcontext.Categories.FirstOrDefaultAsync(m => m.Id == id);
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

        public async Task EditPicture(Category categoryModel, Picture picObj)
        {
            //categoryModel.PictureId = picObj.Id;

            //var categorypicture = categoryModel.categoryPictures[0];
            //categoryModel.categoryPictures[0].picture = picObj;
            //_dbcontext.categoryPictures.Update(categorypicture);
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
        public async Task AddCategoryTODiscount(Category category, int discountID)
        {
            var checkCategory = _dbcontext.discountCategories.FirstOrDefault(x => x.CategoryId == category.Id);
            if (checkCategory == null)
            {
                var dp = new DiscountCategory
                {
                    CategoryId = category.Id,
                    DiscountsId = discountID
                };
                _dbcontext.discountCategories.Add(dp);
            }
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
