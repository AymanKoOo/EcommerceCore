using Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Interfaces
{
    public interface IRoleRepo:IGenericRepo<ApplicationRole>
    {
        public IQueryable<ApplicationRole> GetAll();
        public ApplicationRole GetByID(string roleID);
        

    }
}
