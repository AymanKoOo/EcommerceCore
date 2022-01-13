using AutoMapper;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Services;
using Web.ViewModels.Order;
using Microsoft.AspNetCore.Identity;
using Web.Areas.Admin.ViewModels.Orders;

namespace Web.Areas.Admin.Factories
{
    public class OrderModelFactory : IOrderModelFactory
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IShoppingCartService shoppingCartService;

        public OrderModelFactory(IUnitOfWork unitOfWork, IMapper mapper, IShoppingCartService shoppingCartService)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.shoppingCartService = shoppingCartService;
        }


        public async Task<CheckOut> PrepareCheckOutModel(string Useremail)
        {
            var model = await shoppingCartService.GetCartAsync();
            var shippingMethods = unitOfWork.shippingRepo.getAllShippingMethods();
            var paymentMethods = unitOfWork.paymentRepo.getAllPaymentMethodsAsync();

            var userShippingAddress =  unitOfWork.Admin.GetUserShippingAddress(Useremail);

            var CheckOutmodel = new CheckOut()
            {
                paymentMethods = paymentMethods,
                shippingAddress = userShippingAddress,
                shippingMethods = shippingMethods,
                shopCart = model
            };
            return CheckOutmodel;
        }
        public virtual async Task<OrderListModel> PrepareOrderListModelAsync(int pageSize, int pageNumber)
        {
            var orders = unitOfWork.orderRepo.GetAllProductsList(pageSize, pageNumber);

            var model = new OrderListModel().PrepareToGrid(orders, () =>
            {
                //fill in model values from the entity
                return orders.Data.Select(orders =>
                {
                    return orders;
                });
            });
            //jquery create table gets products view it 
            //button add to dicount new form all check boxes will be added 
            //000000000000000000000000000000000000000000000000000
            //Home page show alll products with category old price new price show dicount

            //
            return model;
        }
    }
}
