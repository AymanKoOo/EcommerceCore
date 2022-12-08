using AyyBlog.ViewModel;
using Core.Entites;
using Core.Entites.Orders;
using Core.Entites.Shipping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Media
{
    public interface IOrderRepo : IGenericRepo<Order>
    {
        IEnumerable<Order> getAllOrders();
        Task AddOrderItem(OrderItem entity);
        PagedList<Order> GetAllProductsList(int pageSize, int pageNumber);
        Order GetOrderById(int id);
        IQueryable<OrderItem> GetOrderItemById(int id);
        Task AddShipmentItem(ShipmentItem shipmentItem);
        Task AddShipment(Shipment shipment);
        IQueryable<OrderItem> GetOrderItemOfProduct(int id);
        List<Order> GetMyOrders(string userEmail);
    }
}
