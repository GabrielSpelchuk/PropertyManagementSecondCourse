using Microsoft.EntityFrameworkCore;
using PropertyManagement.DAL.Repositories.Interfaces;
using PropertyManagement.DAL.Data;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace PropertyManagement.DAL.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly AppDbContext _context;
        protected readonly DbSet<T> _dbSet;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync() => await _dbSet.ToListAsync();
        public virtual async Task<T?> GetByIdAsync(int id) => await _dbSet.FindAsync(id);
        public virtual async Task AddAsync(T entity) => await _dbSet.AddAsync(entity);
        public virtual void Remove(T entity) => _dbSet.Remove(entity);
    }
}
