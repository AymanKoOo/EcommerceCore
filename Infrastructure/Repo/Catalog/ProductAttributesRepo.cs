﻿using Core.Entites.Catalog;
using Core.Interfaces.Catalog;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Core.Entites;

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
        public  IEnumerable<int> GetProductAttributeOptionUsedByProduct(int productID)
        {
           return  _dbcontext.productAttributeMappings.Where(x => x.ProductId == productID).Select(x => x.ProductAttributeId);
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
        public async Task<List<ProductAttributeOption>> GetListProductAttrOptionByID(List<int> ids)
        {
            List<ProductAttributeOption> options = new List<ProductAttributeOption>();
            if (ids != null) { 
            foreach (var id in ids)
            {
                if (id < 0) return null;
                var option = await _dbcontext.productAttributeOptions.Include(x=>x.productAttributeMapping).ThenInclude(x=>x.productAttribute).FirstOrDefaultAsync(x => x.Id == id);
                options.Add(option);
            }
            }
            return options;
        }
        //public  async Task<ProductAttribute> GetProductAttrByOptionID(int id)
        //{
        //    //if (id < 0) return null;
        //    //return await _dbcontext.productAttributes.FirstOrDefaultAsync(x => x.productAttributeOptions.Any(x => x.Id == id));
        //}

        public async Task<ProductAttributeOption> GetProductAttrOptionByName(string name)
        {
            if (name==null) return null;
            return await _dbcontext.productAttributeOptions.FirstOrDefaultAsync(x => x.Name == name);
        }

        public void DeleteProductOptionById(int optionId)
        {
            var option = _dbcontext.productAttributeOptions.FirstOrDefault(x =>x.Id==optionId);
            if (option != null)
            {
                _dbcontext.productAttributeOptions.Remove(option);
            }
        }

        public Task<ProductAttribute> GetProductAttrByOptionID(int id)
        {
            throw new NotImplementedException();
        }

        public decimal getAttributePrices(List<int> optionsIds)
        {
            decimal finalPrice = 0;
            if (optionsIds != null) { 
                foreach(var id in optionsIds)
                {
                   finalPrice += _dbcontext.productAttributeOptions.Where(x => x.Id == id).Select(x => x.PriceAdjustment).Single();
                }
            }
            return finalPrice;
        }
      
    }
}
