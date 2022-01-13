using AyyBlog.ViewModel;
using Core.Entites.Orders;
using Core.Interfaces.Media;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Core.Entites.Shipping;

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

        public PagedList<Order> GetAllProductsList(int pageSize, int pageNumber)
        {
            var orders = _dbcontext.Orders.Include(x => x.customer);

            return PagedList<Order>.ToPagedList(orders,
            pageNumber,
            pageSize);
        }

        public Order GetOrderById(int id)
        {
            var orders = _dbcontext.Orders
                .Include(x => x.customer)
                .Include(x=>x.ShippingAddress).FirstOrDefault(x => x.Id == id);

            return orders;
        }
        public IQueryable<OrderItem> GetOrderItemById(int id)
        {
            var orderItem = _dbcontext.orderItems.Where(x => x.Id == id)
                .Include(x => x.product);

            return orderItem;
        }
        public async Task AddShipmentItem(ShipmentItem shipmentItem)
        {
            await _dbcontext.shipmentItems.AddAsync(shipmentItem);
        }
        public async Task AddShipment(Shipment shipment)
        {
            await _dbcontext.shipments.AddAsync(shipment);
        }
    }
}