using Core.Interfaces;
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

        public UnitOfWork(DataContext context, IAdminRepo adminRepo,IProductRepo productRepo)
        {
            this._dbContext = context;

            this.Admin = adminRepo;

            this.Product = productRepo;
        }

        public int Commit()
        {
            return _dbContext.SaveChanges();
        }

        public void Dispose()
        {
         
        }

        Task IUnitOfWork.Commit()
        {
            throw new NotImplementedException();
        }
    }
}
