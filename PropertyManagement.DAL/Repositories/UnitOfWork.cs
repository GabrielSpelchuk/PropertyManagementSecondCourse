using PropertyManagement.DAL.Repositories.Interfaces;
using PropertyManagement.DAL.Data;
using System.Threading.Tasks;

namespace PropertyManagement.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public IPropertyRepository Properties { get; }

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            Properties = new PropertyRepository(_context);
        }

        public IGenericRepository<T> GetRepository<T>() where T : class
        {
            return new GenericRepository<T>(_context);
        }

        public async Task<int> SaveAsync() => await _context.SaveChangesAsync();
        public void Dispose() => _context.Dispose();
    }
}
