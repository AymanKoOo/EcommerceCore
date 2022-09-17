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

        //public Product GetProduct(int productId)
        //{
        //    return _dbcontext.products.Include(x => x.Category).Include(x => x.productPictures).ThenInclude(x => x.picture).Include(x => x.ProductAttributeOptionsMappings).ThenInclude(x => x.productAttributeOption).ThenInclude(x => x.productAttribute).FirstOrDefault(m => m.Id == productId);
        //}

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

        public PagedList<Product> GetProductsByCatgoryList(int catgoryID, int pageSize, int pageNumber, List<SpecificationAttributeOption> filterSpec, int OrderFilter)
        {
            if (filterSpec.Count > 0 && OrderFilter > 0)
            {

                if ((int)OrderByFilterOptions.HightToLow == OrderFilter)
                {
                    var options = new List<int>();
                    foreach (var i in filterSpec)
                    {
                        options.Add(i.Id);
                    }

                    var filterProducts =
                 _dbcontext.products.Where(x => x.CategoryId == catgoryID)
                 .Include(x => x.ProductSpecificationAttributes).ThenInclude(x => x.specificationAttributeOption)
                 .Include(d => d.Discounts).Include(p => p.productPictures).ThenInclude(e => e.picture)
                 .Where(x =>
                        x.ProductSpecificationAttributes.Any(e =>
                                                options.Contains(e.SpecificationAttributeOptionId))).OrderByDescending(x => x.Price);

                    return PagedList<Product>.ToPagedList(filterProducts,
                    pageNumber,
                    pageSize);

                }

                else if ((int)OrderByFilterOptions.LowToHigh == OrderFilter)
                {

                    var options = new List<int>();
                    foreach (var i in filterSpec)
                    {
                        options.Add(i.Id);
                    }

                    var filterProducts =
                 _dbcontext.products.Where(x => x.CategoryId == catgoryID)
                 .Include(x => x.ProductSpecificationAttributes).ThenInclude(x => x.specificationAttributeOption)
                 .Include(d => d.Discounts).Include(p => p.productPictures).ThenInclude(e => e.picture)
                 .Where(x =>
                        x.ProductSpecificationAttributes.Any(e =>
                                                options.Contains(e.SpecificationAttributeOptionId))).OrderBy(x => x.Price);

                    return PagedList<Product>.ToPagedList(filterProducts,
                    pageNumber,
                    pageSize);
                }

            }
            if (filterSpec.Count > 0 && OrderFilter == 0)
            {

                var options = new List<int>();
                foreach (var i in filterSpec)
                {
                    options.Add(i.Id);
                }

                var filterProducts =
             _dbcontext.products.Where(x => x.CategoryId == catgoryID)
             .Include(x => x.ProductSpecificationAttributes).ThenInclude(x => x.specificationAttributeOption)
             .Include(d => d.Discounts).Include(p => p.productPictures).ThenInclude(e => e.picture)
             .Where(x =>
                    x.ProductSpecificationAttributes.Any(e =>
                                            options.Contains(e.SpecificationAttributeOptionId)));

                return PagedList<Product>.ToPagedList(filterProducts,
                pageNumber,
                pageSize);


            }
            if (filterSpec.Count == 0 && (int)OrderByFilterOptions.HightToLow == OrderFilter)
            {
                var products = _dbcontext.products.Include(d => d.Discounts).Where(x => x.CategoryId == catgoryID).Include(p => p.productPictures).ThenInclude(e => e.picture).OrderByDescending(x => x.Price);
                return PagedList<Product>.ToPagedList(products,
                 pageNumber,
                 pageSize);
            }

            if (filterSpec.Count == 0 && (int)OrderByFilterOptions.LowToHigh == OrderFilter)
            {
                var products = _dbcontext.products.Include(d => d.Discounts).Where(x => x.CategoryId == catgoryID).Include(p => p.productPictures).ThenInclude(e => e.picture)
                .OrderBy(x => x.Price);
                return PagedList<Product>.ToPagedList(products,
                 pageNumber,
                 pageSize);
            }
            else
            {
                var products = _dbcontext.products.Include(d => d.Discounts).Where(x => x.CategoryId == catgoryID).Include(p => p.productPictures).ThenInclude(e => e.picture);
                return PagedList<Product>.ToPagedList(products,
                 pageNumber,
                 pageSize);
            }
        }

        public IQueryable<Product> FindAll()
        {
            //  dataContext.post.Include(a => a.applicationUser);

            return _dbcontext.products; ;
        }

        public PagedList<Product> GetProducts(int pageSize, int pageNumber)
        {
            return PagedList<Product>.ToPagedList(FindAll().OrderBy(on => on.Name),
            pageNumber,
            pageSize);
        }

        public PagedList<Product> GetAllProductsList(int pageSize, int pageNumber)
        {
            var products = _dbcontext.products.Include(x => x.Category);

            return PagedList<Product>.ToPagedList(products,
            pageNumber,
            pageSize);
        }
        public PagedList<Product> GetAllProductsWithoutDiscountList(int pageSize, int pageNumber)
        {
            var products = _dbcontext.products.Include(x => x.Category).Where(x => x.HasDiscountsApplied == false);

            return PagedList<Product>.ToPagedList(products,
            pageNumber,
            pageSize);
        }


        public PagedList<Product> GetProductsWithAppliedDiscountSAsync(List<int> discountId, List<SpecificationAttributeOption> filterSpec, int pageSize, int pageNumber, int OrderFilter)
        {
            if (filterSpec.Count > 0 && OrderFilter > 0)
            {

                if ((int)OrderByFilterOptions.HightToLow == OrderFilter && discountId.Count > 0)
                {
                    var options = new List<int>();
                    foreach (var i in filterSpec)
                    {
                        options.Add(i.Id);
                    }

                    var products = _dbcontext.products.Where(x => x.HasDiscountsApplied);
                    var filterProducts =
                      (from product in products
                       join dpm in _dbcontext.discountProducts on product.Id equals dpm.ProductsId
                       where discountId.Contains(dpm.DiscountsId)   
                       select product).Include(x => x.productPictures).ThenInclude(x => x.picture).Include(x => x.ProductSpecificationAttributes)
                               .ThenInclude(x => x.specificationAttributeOption).ThenInclude(x => x.specificationAttribute).Where(x =>
                        x.ProductSpecificationAttributes.Any(e =>
                                                options.Contains(e.SpecificationAttributeOptionId))).OrderByDescending(x => x.Price);
               
                    return PagedList<Product>.ToPagedList(filterProducts,
                    pageNumber,
                    pageSize);
                }

                else if ((int)OrderByFilterOptions.LowToHigh == OrderFilter && discountId.Count >= 0)
                {

                    var options = new List<int>();
                    foreach (var i in filterSpec)
                    {
                        options.Add(i.Id);
                    }

                    var products = _dbcontext.products.Where(x => x.HasDiscountsApplied);
                    var filterProducts =
                      (from product in products
                       join dpm in _dbcontext.discountProducts on product.Id equals dpm.ProductsId
                       where discountId.Contains(dpm.DiscountsId)
                       select product).Include(x => x.productPictures).ThenInclude(x => x.picture).Include(x => x.ProductSpecificationAttributes)
                               .ThenInclude(x => x.specificationAttributeOption).ThenInclude(x => x.specificationAttribute);

                    filterProducts.Where(x =>
                        x.ProductSpecificationAttributes.Any(e =>
                                                options.Contains(e.SpecificationAttributeOptionId))).OrderBy(x => x.Price);

                    return PagedList<Product>.ToPagedList(filterProducts,
                    pageNumber,
                    pageSize);
                }
            }
            if (filterSpec.Count > 0 && OrderFilter == 0)
            {

                var options = new List<int>();
                foreach (var i in filterSpec)
                {
                    options.Add(i.Id);
                }

                var products = _dbcontext.products.Where(x => x.HasDiscountsApplied);
                var filterProducts =
                  (from product in products
                   join dpm in _dbcontext.discountProducts on product.Id equals dpm.ProductsId
                   where discountId.Contains(dpm.DiscountsId)
                   select product).Include(x => x.productPictures).ThenInclude(x => x.picture).Include(x => x.ProductSpecificationAttributes)
                           .ThenInclude(x => x.specificationAttributeOption).ThenInclude(x => x.specificationAttribute).Where(x =>
                    x.ProductSpecificationAttributes.Any(e =>
                                                options.Contains(e.SpecificationAttributeOptionId)));
              
           
                return PagedList<Product>.ToPagedList(filterProducts,
                pageNumber,
                pageSize);
            }
            if (filterSpec.Count == 0 && (int)OrderByFilterOptions.HightToLow == OrderFilter)
            {
                var options = new List<int>();
                foreach (var i in filterSpec)
                {
                    options.Add(i.Id);
                }

                var products = _dbcontext.products.Where(x => x.HasDiscountsApplied);
                var filterProducts =
                  (from product in products
                   join dpm in _dbcontext.discountProducts on product.Id equals dpm.ProductsId
                   where discountId.Contains(dpm.DiscountsId)
                   select product).OrderByDescending(x => x.Price).Include(x => x.productPictures).ThenInclude(x => x.picture).Include(x => x.ProductSpecificationAttributes)
                           .ThenInclude(x => x.specificationAttributeOption).ThenInclude(x => x.specificationAttribute);

                return PagedList<Product>.ToPagedList(filterProducts,
                pageNumber,
                pageSize);
            }
            if (filterSpec.Count == 0 && (int)OrderByFilterOptions.LowToHigh == OrderFilter)
            {
                var options = new List<int>();
                foreach (var i in filterSpec)
                {
                    options.Add(i.Id);
                }

                var products = _dbcontext.products.Where(x => x.HasDiscountsApplied);
                var filterProducts =
                  (from product in products
                   join dpm in _dbcontext.discountProducts on product.Id equals dpm.ProductsId
                   where discountId.Contains(dpm.DiscountsId)
                   select product).OrderBy(x => x.Price).Include(x => x.productPictures).ThenInclude(x => x.picture).Include(x => x.ProductSpecificationAttributes)
                           .ThenInclude(x => x.specificationAttributeOption).ThenInclude(x => x.specificationAttribute);

                return PagedList<Product>.ToPagedList(filterProducts,
                pageNumber,
                pageSize);
            }
            else
            {
                var options = new List<int>();
                foreach (var i in filterSpec)
                {
                    options.Add(i.Id);
                }

                var products = _dbcontext.products.Where(x => x.HasDiscountsApplied);
                var filterProducts =
                  (from product in products
                   join dpm in _dbcontext.discountProducts on product.Id equals dpm.ProductsId
                   where discountId.Contains(dpm.DiscountsId)
                   select product).Include(x => x.productPictures).ThenInclude(x => x.picture).Include(x => x.ProductSpecificationAttributes)
                           .ThenInclude(x => x.specificationAttributeOption).ThenInclude(x => x.specificationAttribute);

                return PagedList<Product>.ToPagedList(filterProducts,
                pageNumber,
                pageSize);
            }
        }
        public PagedList<Product> GetProductsWithAppliedDiscountAsync(int discountId, List<SpecificationAttributeOption> filterSpec, int pageSize, int pageNumber, int OrderFilter)
         {
            if (filterSpec.Count > 0 && OrderFilter > 0)
            {

                if ((int)OrderByFilterOptions.HightToLow == OrderFilter && discountId >= 0)
                {
                    var options = new List<int>();
                    foreach (var i in filterSpec)
                    {
                        options.Add(i.Id);
                    }

                    var products = _dbcontext.products.Where(x => x.HasDiscountsApplied);
                    var filterProducts =
                      (from product in products
                            join dpm in _dbcontext.discountProducts on product.Id equals dpm.ProductsId
                            where dpm.DiscountsId == discountId
                            select product).Include(x => x.productPictures).ThenInclude(x => x.picture).Include(x => x.ProductSpecificationAttributes)
                               .ThenInclude(x => x.specificationAttributeOption).ThenInclude(x => x.specificationAttribute);

                    filterProducts.Where(x =>
                        x.ProductSpecificationAttributes.Any(e =>
                                                options.Contains(e.SpecificationAttributeOptionId))).OrderByDescending(x => x.Price);

                    return PagedList<Product>.ToPagedList(products,
                    pageNumber,
                    pageSize);
                }

                else if ((int)OrderByFilterOptions.LowToHigh == OrderFilter && discountId >= 0)
                {

                    var options = new List<int>();
                    foreach (var i in filterSpec)
                    {
                        options.Add(i.Id);
                    }

                    var products = _dbcontext.products.Where(x => x.HasDiscountsApplied);
                    var filterProducts =
                      (from product in products
                       join dpm in _dbcontext.discountProducts on product.Id equals dpm.ProductsId
                       where dpm.DiscountsId == discountId
                       select product).Include(x => x.productPictures).ThenInclude(x => x.picture).Include(x => x.ProductSpecificationAttributes)
                               .ThenInclude(x => x.specificationAttributeOption).ThenInclude(x => x.specificationAttribute).Where(x =>
                        x.ProductSpecificationAttributes.Any(e =>
                                                options.Contains(e.SpecificationAttributeOptionId))).OrderBy(x => x.Price);
                
                    return PagedList<Product>.ToPagedList(filterProducts,
                    pageNumber,
                    pageSize);
                }
            }
            if (filterSpec.Count > 0 && OrderFilter == 0)
            {

                var options = new List<int>();
                foreach (var i in filterSpec)
                {
                    options.Add(i.Id);
                }

                var products = _dbcontext.products.Where(x => x.HasDiscountsApplied);
                var filterProducts =
                  (from product in products
                   join dpm in _dbcontext.discountProducts on product.Id equals dpm.ProductsId
                   where dpm.DiscountsId == discountId
                   select product).Include(x => x.productPictures).ThenInclude(x => x.picture).Include(x => x.ProductSpecificationAttributes)
                           .ThenInclude(x => x.specificationAttributeOption).ThenInclude(x => x.specificationAttribute).Where(x =>
                    x.ProductSpecificationAttributes.Any(e =>
                                                options.Contains(e.SpecificationAttributeOptionId)));
          
                return PagedList<Product>.ToPagedList(filterProducts,
                pageNumber,
                pageSize);
            }
            if (filterSpec.Count == 0 && (int)OrderByFilterOptions.HightToLow == OrderFilter)
            {
                var options = new List<int>();
                foreach (var i in filterSpec)
                {
                    options.Add(i.Id);
                }

                var products = _dbcontext.products.Where(x => x.HasDiscountsApplied);
                var filterProducts =
                  (from product in products
                   join dpm in _dbcontext.discountProducts on product.Id equals dpm.ProductsId
                   where dpm.DiscountsId == discountId
                   select product).OrderByDescending(x => x.Price).Include(x => x.productPictures).ThenInclude(x => x.picture).Include(x => x.ProductSpecificationAttributes)
                           .ThenInclude(x => x.specificationAttributeOption).ThenInclude(x => x.specificationAttribute);

                return PagedList<Product>.ToPagedList(filterProducts,
                pageNumber,
                pageSize);
            }

            if (filterSpec.Count == 0 && (int)OrderByFilterOptions.LowToHigh == OrderFilter)
            {
                var options = new List<int>();
                foreach (var i in filterSpec)
                {
                    options.Add(i.Id);
                }

                var products = _dbcontext.products.Where(x => x.HasDiscountsApplied);
                var filterProducts =
                  (from product in products
                   join dpm in _dbcontext.discountProducts on product.Id equals dpm.ProductsId
                   where dpm.DiscountsId == discountId
                   select product).OrderBy(x => x.Price).Include(x => x.productPictures).ThenInclude(x => x.picture).Include(x => x.ProductSpecificationAttributes)
                           .ThenInclude(x => x.specificationAttributeOption).ThenInclude(x => x.specificationAttribute);

                return PagedList<Product>.ToPagedList(filterProducts,
                pageNumber,
                pageSize);
            }
            else
            {
                var options = new List<int>();
                foreach (var i in filterSpec)
                {
                    options.Add(i.Id);
                }

                var products = _dbcontext.products.Where(x => x.HasDiscountsApplied);
                var filterProducts =
                  (from product in products
                   join dpm in _dbcontext.discountProducts on product.Id equals dpm.ProductsId
                   where dpm.DiscountsId == discountId
                   select product).Include(x => x.productPictures).ThenInclude(x => x.picture).Include(x => x.ProductSpecificationAttributes)
                           .ThenInclude(x => x.specificationAttributeOption).ThenInclude(x => x.specificationAttribute);

                return PagedList<Product>.ToPagedList(filterProducts,
                pageNumber,
                pageSize);
            }
        }

        public async Task AddProductTODiscount(Product product, int discountID)
        {
            var checkProduct = _dbcontext.discountProducts.FirstOrDefault(x => x.ProductsId == product.Id);
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
            return await _dbcontext.products.Include(d => d.Discounts).Include(q => q.Category).Include(x => x.productPictures).ThenInclude(e => e.picture).ToListAsync();
        }


        public async Task AddProductSpecificationAttribute(ProductSpecificationAttribute model)
        {
            await _dbcontext.ProductSpecificationAttribute.AddAsync(model);
        }

        //public async Task<ProductAttributeOptionsMapping> GetProductAttrByID(int productID)
        //{
        //    return await _dbcontext.productAttributeOptionsMappings.Include(x => x.productAttributeOption).FirstOrDefaultAsync(x => x.ProductId == productID);
        //}

        public List<Picture> GetProductPictures(int productId)
        {
            var pics = new List<Picture>();
            var q = _dbcontext.products.Where(x => x.Id == productId).Include(x => x.productPictures).ThenInclude(x => x.picture).FirstOrDefault();
            foreach (var pic in q.productPictures)
            {
                pics.Add(pic.picture);
            }
            return pics;
        }

        //public Task AddProductAttribute(ProductAttributeOptionsMapping model)
        //{
        //    throw new NotImplementedException();
        //}



        //public async Task AddProductAttributeOptionMapping(ProductAttributeOptionsMapping model)
        //{
        //    await _dbcontext.productAttributeOptionsMappings.AddAsync(model);
        //}
        //public async Task AddProductAttributeMapping(ProductAttributeMapping model)
        //{
        //    await _dbcontext.productAttributeMappings.AddAsync(model);
        //}
        //public void UpdateProductAttribute(ProductAttributeOptionsMapping model)
        //{
        //    //_dbcontext.productAttributeOptionsMappings.Update(model);
        //}


        //public async Task<Product> GetProductAttrMappingByProductID(int id)
        //{
        //    if (id< 0) return null;
        //    return await _dbcontext.products.Include(x=>x.ProductAttributeMappings).ThenInclude(x=>x.productAttribute).ThenInclude(x => x.productAttributeOptions).ThenInclude(x => x.ProductAttributeOptionsMappings).FirstOrDefaultAsync(x => x.Id == id);
        //}

        public async Task AddProductAttributeMapping(ProductAttributeMapping model)
        {
            await _dbcontext.productAttributeMappings.AddAsync(model);
        }
        public void deleteProductAttrMapping(int mapID)
        {
            var model = _dbcontext.productAttributeMappings.Include(x=>x.productAttributeOptions).FirstOrDefault(x => x.Id == mapID);
            foreach(var options in model.productAttributeOptions)
            {
                _dbcontext.productAttributeOptions.Remove(options);
            }
            _dbcontext.productAttributeMappings.Remove(model);
        }

        public Product GetProduct(int productId)
        {
            return _dbcontext.products.Include(x=>x.productPictures).ThenInclude(x=>x.picture)
                .Include(x=>x.ProductAttributeMappings).ThenInclude(x=>x.productAttributeOptions).FirstOrDefault(x => x.Id == productId);
        }
        //public Product GetProductByGivenAttribute(int[] options,int productId)
        //{
        //    //return _dbcontext.products.Where(x=>x.Id==productId).Include(x=>x.ProductAttributeMappings)
        //}

        
        /// <summary>
        /// ////////
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IEnumerable<ProductAttributeMapping> GetProductAttrMappingByProductID(int id)
        {
            return _dbcontext.productAttributeMappings.Where(x => x.ProductId == id)
                  .Include(x => x.productAttribute).Include(x=>x.productAttributeOptions);
        }

        public async Task<ProductAttributeMapping> GetProductAttrMappingByID(int id)
        {
            return await _dbcontext.productAttributeMappings.Include(x=>x.product).ThenInclude(x=>x.productPictures).ThenInclude(x=>x.picture)
                .Include(x=>x.productAttributeOptions).Include(x=>x.productAttribute).FirstOrDefaultAsync(x => x.Id == id);
        }
        public  List<Product> GetProductByCartList(List<int> IDs)
        {
          return  _dbcontext.products.Where(x => IDs.Any(e => e.Equals(x.Id))).Include(x=>x.productPictures).ThenInclude(
              x=>x.picture).ToList();
        }

       
    }
}
