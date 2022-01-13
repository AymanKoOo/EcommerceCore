using AutoMapper;
using Core.Entites.Shipping;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Areas.Admin.Factories;
using Web.Areas.Admin.ViewModels.Orders;

namespace Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[Controller]")]
    public class OrderController : Controller
    {
        readonly private IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IOrderModelFactory orderModelFactory;

        public OrderController(IUnitOfWork unitOfWork, IMapper mapper, IOrderModelFactory orderModelFactory)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            this.orderModelFactory = orderModelFactory;
        }
  

        public async Task<IActionResult> Index(int pageSize = 5, int pageNumber = 1)
        {
            var orders = await orderModelFactory.PrepareOrderListModelAsync(pageSize, pageNumber);
            return View(orders);
        }

        [HttpGet("OrderDetails")]
        public async Task<IActionResult> OrderDetails(int orderId)
        {
            var order = _unitOfWork.orderRepo.GetOrderById(orderId);
            var orderItem = _unitOfWork.orderRepo.GetOrderItemById(orderId);

            var model = new OrderDetail
            {
                order = order,
                orderItem = orderItem
            };

            return View(model);
        }
        [HttpGet("CancelOrder")]
        public async Task<IActionResult> CancelOrder(int orderId)
        {
            var order = _unitOfWork.orderRepo.GetOrderById(orderId);
            order.OrderStatusId = 20;
            _unitOfWork.orderRepo.Update(order);
            return View();
        }

        [HttpGet("AddShipment")]
        public async Task<IActionResult> AddShipment(int orderId)
        {
            var orderItem = _unitOfWork.orderRepo.GetOrderItemById(orderId);
            return View(orderItem);
        }

        [HttpGet("AddOrderToShipment")]
        public async Task<IActionResult> AddOrderToShipment(int orderId)
        {
            var order = _unitOfWork.orderRepo.GetOrderById(orderId);
            var orderItem = _unitOfWork.orderRepo.GetOrderItemById(orderId);

            var shipment = new Shipment
            {
                OrderId = orderId,
                CreatedOnUtc = (DateTime)order.PaidDateUtc 
            };

            await _unitOfWork.orderRepo.AddShipment(shipment);
            _unitOfWork.Save();
          
            foreach (var item in orderItem)
            {
                var shipmentItem = new ShipmentItem
                {
                    ShipmentId= shipment.Id,
                    OrderItem = item.Id,
                    orderItem = item
                };
                await _unitOfWork.orderRepo.AddShipmentItem(shipmentItem);
            }
            order.ShippingStatusId = 30;
            _unitOfWork.orderRepo.Update(order);
            _unitOfWork.Save();
            return View("/");
        }
    }
}
