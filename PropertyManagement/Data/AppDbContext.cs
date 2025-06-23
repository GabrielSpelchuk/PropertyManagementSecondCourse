using Microsoft.EntityFrameworkCore;
using PropertyManagement.Enteties;

namespace PropertyManagement.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<PropertyType> PropertyTypes { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options ) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

            modelBuilder.Entity<PropertyType>().HasData(
                new PropertyType { Id = 1, Name = "Apartment" },
                new PropertyType { Id = 2, Name = "House" },
                new PropertyType { Id = 3, Name = "Commercial" }
            );

            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, FullName = "Ivan Petrenko", Email = "ivan@example.com", PasswordHash = "hashed", Role = "Seller" }
            );

            modelBuilder.Entity<Property>().HasData(
                new Property
                {
                    Id = 1,
                    Title = "Modern Apartment",
                    Address = "Lviv, Franka St.",
                    Price = 55000,
                    Description = "2-bedroom, cozy, balcony",
                    PropertyTypeId = 1,
                    OwnerId = 1,
                    CreatedAt = new DateTime(2024, 6, 23)
                }
            );
        }
    }
}
