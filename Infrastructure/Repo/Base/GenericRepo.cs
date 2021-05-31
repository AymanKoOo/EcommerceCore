using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Repo
{
    public class GenericRepo<T> : IGenericRepo<T> where T : class
    {
        private readonly DataContext _dbcontext;
        private DbSet<T> table = null;

        public GenericRepo(DataContext dbcontext)
        {
            _dbcontext = dbcontext;
            table = _dbcontext.Set<T>();
        }

       
        public bool Delete(T model)
        {
            
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            throw new NotImplementedException();
        }

      
    }
}
