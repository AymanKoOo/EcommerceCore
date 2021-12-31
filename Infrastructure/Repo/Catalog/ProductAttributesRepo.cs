using Core.Entites.Catalog;
using Core.Interfaces.Catalog;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repo.Catalog
{
    public class ProductAttributesRepo : GenericRepo<ProductAttribute>, IProductAttributesRepo
    {
        private readonly DataContext _dbcontext;
        public ProductAttributesRepo(DataContext dbcontext) : base(dbcontext)
        {
            this._dbcontext = dbcontext;
        }

        public async Task CreateProductAttributeOption(ProductAttributeOption model)
        {
            await _dbcontext.productAttributeOptions.AddAsync(model);
        }

        public async Task<IEnumerable<ProductAttributeOption>> GetAllProductAttributeOption()
        {
            return await _dbcontext.productAttributeOptions.ToListAsync();
        }

        public async Task<IEnumerable<ProductAttribute>> GetAllProductAttributes()
        {
            return await _dbcontext.productAttributes.ToListAsync();
        }

        public async Task<ProductAttribute> GetProductAttrByID(int id)
        {
            if (id < 0) return null;
            return await _dbcontext.productAttributes.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ProductAttributeOption> GetProductAttrOptionByID(int id)
        {
            if (id < 0) return null;
            return await _dbcontext.productAttributeOptions.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ProductAttributeOption> GetProductAttrOptionByName(string name)
        {
            if (name==null) return null;
            return await _dbcontext.productAttributeOptions.FirstOrDefaultAsync(x => x.Name == name);
        }
    }
}
