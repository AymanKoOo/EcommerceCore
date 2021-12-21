using Core.Entites.Catalog;
using Core.Interfaces.Catalog;
using Core.Interfaces.Discounts;
using Core.Interfaces.Media;
using Infrastructure.Repo;
using System;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {

        IAdminRepo Admin { get; }
        IProductRepo Product { get; }
        ICategoryRepo Category { get; }
        ICustomerRepo Customer { get; }
        IRoleRepo role { get; }
        IDiscount discount { get; }
        IPictureRepo picture { get; }
        ISpecificationAttributesRepo SpecificationAttributes { get; }
        void Save();
    }
}
