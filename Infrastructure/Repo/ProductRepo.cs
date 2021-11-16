using Core.Entites;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Repo
{
    public class ProductRepo : GenericRepo<Product>, IProductRepo
    {
        private readonly DataContext _dbcontext;
        public ProductRepo(DataContext dbcontext) : base(dbcontext)
        {
            this._dbcontext = dbcontext;
        }

        //public void AddProduct(Product product)
        //{
        //        _dbcontext.products.Add(product);
        //}

        //public void DeleteProduct(Product product)
        //{
        //    _dbcontext.products.Remove(product);
        //}

        //public void EditProduct(Product product)
        //{
        //  //  _dbcontext.Entry(product).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        //    _dbcontext.Update(product);
        //}

        public Product GetProduct(int productId)
        {
            return _dbcontext.products.Include(x=>x.Category).FirstOrDefault(m => m.Id == productId);
        }

        //public Product GetProduct(int productId)
        //{
        //    return _dbcontext.products.FirstOrDefaultAsync(m => m.Id = productId);
        //}

        public IEnumerable<Product> GetAllProducts()
        {
            return _dbcontext.products.Include(x => x.Category);
        }

        public IEnumerable<Product> GetProductsByCatgory(int catgoryID)
        {
            return from products in _dbcontext.products
                   where products.CategoryId == catgoryID
                   select products;
        }
    }
}
