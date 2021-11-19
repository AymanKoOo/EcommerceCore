using Core.Entites;
using Core.Interfaces.Discounts;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Repo.Discounts
{
    public class DiscountRepo:GenericRepo<Discount>,IDiscount
    {
        private readonly DataContext _dbcontext;

        public DiscountRepo(DataContext dbcontext) : base(dbcontext)
        {
            this._dbcontext = dbcontext;
        }

        public List<Discount> GetAll()
        {
            return _dbcontext.discounts.ToList();
        }

        public Discount GetByID(int id)
        {
            return _dbcontext.discounts.FirstOrDefault(x => x.Id == id);
        }
    }
}
