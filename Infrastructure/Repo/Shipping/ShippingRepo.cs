using Core.Entites;
using Core.Entites.Shipping;
using Infrastructure.Data;
using Infrastructure.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Media
{
    public class ShippingRepo : GenericRepo<ShippingMethods>, IShippingRepo
    {
        private readonly DataContext _dbcontext;
        public ShippingRepo(DataContext dbcontext) : base(dbcontext)
        {
            this._dbcontext = dbcontext;
        }

        public List<ShippingMethods> getAllShippingMethods()
        {
            return _dbcontext.shippingMethods.ToList();
        }
    }
}
