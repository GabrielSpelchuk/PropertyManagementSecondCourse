using Microsoft.EntityFrameworkCore;
using PropertyManagement.DAL.Repositories.Interfaces;
using PropertyManagement.DAL.Data;
using PropertyManagement.DAL.Entities;


namespace PropertyManagement.DAL.Repositories
{
    public class PropertyRepository : GenericRepository<Property>, IPropertyRepository
    {
        public PropertyRepository(AppDbContext context) : base(context) { }
    }
}
