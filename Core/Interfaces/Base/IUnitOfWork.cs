using Infrastructure.Repo;
using System;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {

        IAdminRepo Admin { get; }

        IProductRepo Product { get; }
        Task Commit();
    }
}
