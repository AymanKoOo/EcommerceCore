using AyyBlog.ViewModel;
using Core.Entites;
using Core.Entites.Catalog;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

      
        public async Task<Product> GetProductByName(string name)
        {
            return await _dbcontext.products.FirstOrDefaultAsync(x => x.Name == name);
        }
        public async Task AddPicture(int prdouctID, int picID)
        {
            var model = new ProductPicture
            {
                ProductId = prdouctID,
                PictureId = picID
            };
            await _dbcontext.productPictures.AddAsync(model);
        }
        public IEnumerable<Product> GetProductsByCatgory(int catgoryID)
        {
            return from products in _dbcontext.products
                   where products.CategoryId == catgoryID
                   select products;
        }



        public IQueryable<Product> FindAll()
        {
            //  dataContext.post.Include(a => a.applicationUser);

            return _dbcontext.products;               ;
        }

        public PagedList<Product> GetProducts(int pageSize, int pageNumber)
        {
            return PagedList<Product>.ToPagedList(FindAll().OrderBy(on => on.Name),
            pageNumber,
            pageSize);
        }

        public PagedList<Product> GetAllProductsList(int pageSize, int pageNumber)
        {
            var products =  _dbcontext.products.Include(x => x.Category);
           
            return PagedList<Product>.ToPagedList(products,
            pageNumber,
            pageSize);
        }
        public PagedList<Product> GetAllProductsWithoutDiscountList(int pageSize, int pageNumber)
        {
            var products = _dbcontext.products.Include(x => x.Category).Where(x=>x.HasDiscountsApplied==false);

            return PagedList<Product>.ToPagedList(products,
            pageNumber,
            pageSize);
        }
        
        public PagedList<Product> GetProductsWithAppliedDiscountAsync(int discountId, int pageSize, int pageNumber)
        {
            var products = _dbcontext.products.Where(x => x.HasDiscountsApplied);

            if (discountId >= 0)
                products = from product in products
                           join dpm in _dbcontext.discountProducts on product.Id equals dpm.ProductsId
                           where dpm.DiscountsId == discountId
                           select product;

            products = products.OrderBy(product => product.Name).ThenBy(product => product.Id);

            return PagedList<Product>.ToPagedList(products,
            pageNumber,
            pageSize);
        }

        public async Task AddProductTODiscount(Product product, int discountID)
        {
            var checkProduct = _dbcontext.discountProducts.FirstOrDefault(x=>x.ProductsId==product.Id);
            if (checkProduct == null)
            {
                var dp = new DiscountProduct
                {
                    ProductsId = product.Id,
                    DiscountsId = discountID
                };
                _dbcontext.discountProducts.Add(dp);
            }
           
        }
        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await _dbcontext.products.Include(d=>d.Discounts).Include(q=>q.Category).Include(x => x.productPictures).ThenInclude(e => e.picture).ToListAsync();
        }
    }
}
