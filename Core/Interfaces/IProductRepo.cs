using AyyBlog.ViewModel;
using Core.Entites;
using Core.Entites.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IProductRepo:IGenericRepo<Product>
    {
        IEnumerable<Product> GetProductsByCatgory(int catgoryID);

        public Task<Product> GetProductByName(string name);
       
        Task<IEnumerable<Product>> GetAllProducts();

        PagedList<Product> GetProductsByCatgoryList(int catgoryID, int pageSize, int pageNumber,List<SpecificationAttributeOption> filterSpec,int orderFilter);

        public PagedList<Product> GetAllProductsList(int pageSize, int pageNumber);
        public PagedList<Product> GetAllProductsWithoutDiscountList(int pageSize, int pageNumber);
        public  Task AddPicture(int prdouctID, int picID);
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
        public Task AddProductTODiscount(Product product,int discountID);


        public Task AddProductSpecificationAttribute(ProductSpecificationAttribute model);

        //public Task AddProductAttribute(ProductAttributeOptionsMapping model);

        public List<Picture> GetProductPictures(int productId);

        //public Task<ProductAttributeOptionsMapping> GetProductAttrByID(int productID);
        //public void UpdateProductAttribute(ProductAttributeOptionsMapping model);

        //public Task AddProductAttributeOptionMapping(ProductAttributeOptionsMapping model);
        public Task AddProductAttributeMapping(ProductAttributeMapping model);
        public IEnumerable<ProductAttributeMapping> GetProductAttrMappingByProductID(int id);
        public Task<ProductAttributeMapping> GetProductAttrMappingByID(int id);

        public void deleteProductAttrMapping(int mapID);

        public List<Product> GetProductByCartList(List<int> IDs);
    }
}

    