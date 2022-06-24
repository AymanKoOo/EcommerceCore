using AutoMapper;
using Core.Entites.Orders;
using Core.Entites.Payments;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Web.Areas.Admin.Factories;
using Web.Services;
using Web.ViewModels.Order;

namespace Web.Controllers
{

    public class OrderController : Controller
    {
        readonly private IUnitOfWork _unitOfWork;
        private readonly IOrderModelFactory orderModelFactory;
        private readonly IShoppingCartService _shoppingCartService;
        private readonly IMapper _mapper;

        public OrderController(IUnitOfWork unitOfWork, IOrderModelFactory orderModelFactory , IShoppingCartService shoppingCartService, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            this.orderModelFactory = orderModelFactory;
            _shoppingCartService = shoppingCartService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("CheckOut")]
        public virtual async Task<IActionResult> CheckOut()
        {
            string email = User.FindFirst(ClaimTypes.Email)?.Value;
            {
                var model = await orderModelFactory.PrepareCheckOutModel(email);
                return View(model);
            }
        }

        [HttpPost("CheckOut")]
        public virtual async Task<IActionResult> CheckOut(CheckOut checkOut)
        {
            string email = User.FindFirst(ClaimTypes.Email)?.Value;
            {
                if (!string.IsNullOrEmpty(email) && checkOut != null)
                {
                    var cart = await _shoppingCartService.GetCartAsync();
                    var paymentStausId = 0;
                    if (checkOut.paymentMethod == "CashOnDilvery") paymentStausId = 10;
                    var user = await _unitOfWork.Admin.GetUserAndAddress(email);
                    var orderModel = new Order
                    {
                        customer = user,
                        ShippingStatusId=20,
                        OrderTotal = cart.totalPrice,
                        OrderStatusId = ((int)OrderStatus.Compeleted),
                        ShippingAddressId = checkOut.shippingAddressId,
                        PaymentStatusId = paymentStausId,
                        ShippingMethod = checkOut.shippingMethod,
                        PaymentMethodSystemName = checkOut.paymentMethod,
                        PaidDateUtc = DateTime.UtcNow,
                    };
                    await _unitOfWork.orderRepo.Add(orderModel);
                    _unitOfWork.Save();

                    foreach (var item in cart.products)
                    {
                        var orderItem = new OrderItem
                        {
                            OrderId = orderModel.Id,
                            ProductId = item.Id,
                            UnitPriceInclTax = item.Price
                        };
                       await _unitOfWork.orderRepo.AddOrderItem(orderItem);
                    }

                    _unitOfWork.Save();
                    return View("/");
                }
            }
            return View();
        }
    }
}
