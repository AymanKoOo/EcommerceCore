using Core.Entites.Orders;
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
    public class GenericRepo<T> : IGenericRepo<T> where T : class
    {
        private readonly DataContext _dbcontext;
        private DbSet<T> table = null;

        public GenericRepo(DataContext dbcontext)
        {
            _dbcontext = dbcontext;
            table = _dbcontext.Set<T>();
        }


        public async Task Add(T entity)
        {
            await _dbcontext.AddAsync(entity);
        }
      
        public  void Delete(T entity)
        {
            _dbcontext.Remove(entity);
        }


        public void Update(T entity)
        {
            _dbcontext.Update(entity);
        }

    }
}
