using Microsoft.EntityFrameworkCore;
using PropertyManagement.Data.Repositories.Interfaces;
using PropertyManagement.Enteties;


namespace PropertyManagement.Data.Repositories
{
    public class PropertyRepository : GenericRepository<Property>, IPropertyRepository
    {
        public PropertyRepository(AppDbContext context) : base(context) { }
    }
}
