using System;
using System.Threading.Tasks;

namespace PropertyManagement.DAL.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IPropertyRepository Properties { get; }
        IGenericRepository<T> GetRepository<T>() where T : class;
        Task<int> SaveAsync();
    }
}
