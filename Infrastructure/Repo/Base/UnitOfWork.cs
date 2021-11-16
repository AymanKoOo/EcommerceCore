﻿using Core.Interfaces;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repo.Base
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly DataContext _dbContext;

        public IAdminRepo Admin { get; }

        public IProductRepo Product { get; }

        public ICategoryRepo Category { get; }
        public ICustomerRepo Customer { get; }

        public IRoleRepo role { get; }


        public UnitOfWork(DataContext context)
        {
            this._dbContext = context;

            this.Admin = new AdminRepo(_dbContext);

            this.Product = new ProductRepo(_dbContext);

            this.Category = new CategoryRepo(_dbContext);
            this.Customer = new CustomerRepo(_dbContext);
            this.role = new RoleRepo(_dbContext);

        }

        public void Save()
        {
             _dbContext.SaveChanges();
        }

        public void Dispose()
        {
         
        }
    }
}