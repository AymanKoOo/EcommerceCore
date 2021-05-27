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


        public UnitOfWork(DataContext context, IAdminRepo adminRepo)
        {
            this._dbContext = context;

            this.Admin = adminRepo;
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
