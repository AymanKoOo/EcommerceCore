using Core.Entites.Orders;
using Core.Interfaces.Media;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repo.Orders
{
    public class OrderRepo : GenericRepo<Order>, IOrderRepo
    {

        private readonly DataContext _dbcontext;
        public OrderRepo(DataContext dbcontext) : base(dbcontext)
        {
            this._dbcontext = dbcontext;
        }

        public IEnumerable<Order> getAllOrders()
        {
            throw new NotImplementedException();
        }
        public async Task AddOrderItem(OrderItem entity)
        {
            await _dbcontext.orderItems.AddAsync(entity);
        }

    }
}