﻿using System.Collections.Generic;
using System.Threading.Tasks;

namespace PropertyManagement.DAL.Repositories.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetByIdAsync(int id);
        Task AddAsync(T entity);
        void Remove(T entity);
    }
}
