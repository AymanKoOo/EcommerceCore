using Core.Entites;
using Core.Entites.Orders;
using Core.Entites.Shipping;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Media
{
    public interface IOrderRepo : IGenericRepo<Order>
    {
        IEnumerable<Order> getAllOrders();
        Task AddOrderItem(OrderItem entity);
    }
}
