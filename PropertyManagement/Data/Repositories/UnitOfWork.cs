using PropertyManagement.Data.Repositories.Interfaces;

namespace PropertyManagement.Data.Repositories
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

        public async Task<int> SaveAsync() => await _context.SaveChangesAsync();
        public void Dispose() => _context.Dispose();
    }
}
