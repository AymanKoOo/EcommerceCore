using Core.Interfaces;
using Core.Interfaces.Catalog;
using Core.Interfaces.Discounts;
using Core.Interfaces.Media;
using Infrastructure.Data;
using Infrastructure.Repo.Catalog;
using Infrastructure.Repo.Discounts;
using Infrastructure.Repo.Media;
using Infrastructure.Repo.Orders;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repo.Base
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly DataContext _dbContext;

        public IAdminRepo Admin { get; }

        public IProductRepo Product { get; }

        public ICategoryRepo Category { get; }
        public ICustomerRepo Customer { get; }

        public IRoleRepo role { get; }

        public IDiscount discount { get; }
        public IPictureRepo picture { get; }

        public ISpecificationAttributesRepo SpecificationAttributes { get; }

        public IProductAttributesRepo productAttributes { get; }
        public IShippingRepo shippingRepo { get; }

        public IPaymentRepo paymentRepo { get; }
        public IOrderRepo orderRepo { get; }
        public IDealRepo dealRepo { get; }

        public UnitOfWork(DataContext context)
        {
            this._dbContext = context;
            this.Admin = new AdminRepo(_dbContext);
            this.Product = new ProductRepo(_dbContext);
            this.Category = new CategoryRepo(_dbContext);
            this.Customer = new CustomerRepo(_dbContext);
            this.role = new RoleRepo(_dbContext);
            this.discount = new DiscountRepo(_dbContext);
            this.picture = new PictureRepo(_dbContext);
            this.SpecificationAttributes = new SpecificationAttributesRepo(_dbContext);
            this.productAttributes = new ProductAttributesRepo(_dbContext);
            this.shippingRepo = new ShippingRepo(_dbContext);
            this.paymentRepo = new PaymentRepo(_dbContext);
            this.orderRepo = new OrderRepo(_dbContext);
            this.dealRepo = new DealRepo(_dbContext);
        }

        public void Save()
        {
             _dbContext.SaveChanges();
        }

        public void Dispose()
        {
         
        }
    }
}
