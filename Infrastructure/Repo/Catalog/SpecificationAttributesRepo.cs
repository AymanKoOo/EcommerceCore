﻿using Core.Entites.Catalog;
using Core.Interfaces.Catalog;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace Infrastructure.Repo.Catalog
{
    public class SpecificationAttributesRepo : GenericRepo<SpecificationAttribute>, ISpecificationAttributesRepo
    {
        private readonly DataContext _dbcontext;
        public SpecificationAttributesRepo(DataContext dbcontext) : base(dbcontext)
        {
            this._dbcontext = dbcontext;
        }

        public void AddSpecificationAttributeGroup(SpecificationAttributeGroup model)
        {
            _dbcontext.Add(model);
        }

        public async Task<IEnumerable<SpecificationAttributeGroup>> GetAllSpecificationAttributeGroup()
        {
            return await _dbcontext.specificationAttributeGroups.ToListAsync();
        }
        public async Task<IEnumerable<SpecificationAttributeOption>> GetAllSpecificationAttributeOption()
        {
            return await _dbcontext.SpecificationAttributeOptions.ToListAsync();
        }
        public async Task<IEnumerable<SpecificationAttribute>> GetAllSpecificationAttributes()
        {
            return await _dbcontext.specificationAttributes.ToListAsync();
        }
        public async Task CreateSpecificationAttribute(SpecificationAttribute model)
        {
            await _dbcontext.specificationAttributes.AddAsync(model);
        }

        public async Task CreateSpecificationAttributeOption(SpecificationAttributeOption model)
        {
            await _dbcontext.SpecificationAttributeOptions.AddAsync(model);
        }
    }
}
