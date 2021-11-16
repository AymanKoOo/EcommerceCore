using Core.Entites;
using Core.Interfaces;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Repo
{
    public class RoleRepo: GenericRepo<ApplicationRole>,IRoleRepo
    {
        private readonly DataContext _dbcontext;
        public RoleRepo(DataContext dbcontext) : base(dbcontext)
        {
            this._dbcontext = dbcontext;
        }

        public IQueryable<ApplicationRole> GetAll()
        {
            return _dbcontext.Roles;
        }
        public ApplicationRole GetByID(string roleID)
        {
            return _dbcontext.Roles.FirstOrDefault(x=>x.Id==roleID);
        }

    }
}
