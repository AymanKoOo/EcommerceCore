using Core.Entites;
using Core.Interfaces;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Generic;
using System.Linq;
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

        public void DeleteCategory(Category category)
        {
            throw new NotImplementedException();
        }

        public void EditCategory(Category category)
        {
            throw new NotImplementedException();
        }

        public List<Category> GetCategories()
        {
            return (from cat in _dbcontext.Categories
                   select cat).ToList();
        }

        public Category GetCategory(string categoryName)
        {
            return _dbcontext.Categories.FirstOrDefault(m => m.Name == categoryName);
        }

        Product ICategoryRepo.GetCategory(string categoryName)
        {
            throw new NotImplementedException();
        }
    }
}
