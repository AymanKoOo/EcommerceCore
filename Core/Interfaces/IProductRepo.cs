using AyyBlog.ViewModel;
using Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Interfaces
{
    public interface IProductRepo:IGenericRepo<Product>
    {
        IEnumerable<Product> GetProductsByCatgory(int catgoryID);

        IEnumerable<Product> GetAllProducts();

        Product GetProduct(int productId);
        //void AddProduct(Product product);
        //void EditProduct(Product product);
        //void DeleteProduct(Product product);
        //Task<IPagedList<Product>> GetProductsWithAppliedDiscountAsync(int? discountId = null,
        //    bool showHidden = false, int pageIndex = 0, int pageSize = int.MaxValue);

        //IEnumerable<Price> GetPricesOfProduct(int productId);
        //void EditProductPrice(Price price);
        //Price GetCurrentPrice(int productId);
        //Price GetSalePrice(int productId);
        //void AddPriceToProduct(Price price);
        public IQueryable<Product> FindAll();
        public PagedList<Product> GetProducts(int pageSize, int pageNumber);
        public PagedList<Product> GetProductsWithAppliedDiscountAsync(int discountId, int pageSize, int pageNumber);
    }
}
