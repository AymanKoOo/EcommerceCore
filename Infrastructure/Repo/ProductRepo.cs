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

        public void AddProduct(Product product)
        {
                _dbcontext.products.Add(product);
        }

        public void DeleteProduct(Product product)
        {
            _dbcontext.products.Remove(product);
        }

        public void EditProduct(Product product)
        {
            _dbcontext.Entry(product).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public Product GetProduct(int productId)
        {
            throw new NotImplementedException();
        }

        //public Product GetProduct(int productId)
        //{
        //    return _dbcontext.products.FirstOrDefaultAsync(m => m.Id = productId);
        //}

        public IEnumerable<Product> GetProducts()
        {
            return from products in _dbcontext.products
                   select products;
        }
    }
}
