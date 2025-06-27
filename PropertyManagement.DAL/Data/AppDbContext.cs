using Microsoft.EntityFrameworkCore;
using PropertyManagement.DAL.Entities;
using System;

namespace PropertyManagement.DAL.Data
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
                new PropertyType { Id = 3, Name = "Commercial" },
                new PropertyType { Id = 4, Name = "Land Plot" }
            );

            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, FullName = "Olena Tkachenko", Email = "olena.t@example.com", PasswordHash = "hashed1", Role = "Seller" },
                new User { Id = 2, FullName = "Ivan Petrenko", Email = "ivan.p@example.com", PasswordHash = "hashed2", Role = "Buyer" },
                new User { Id = 3, FullName = "Maria Koval", Email = "maria.k@example.com", PasswordHash = "hashed3", Role = "Seller" },
                new User { Id = 4, FullName = "Andrii Shevchenko", Email = "andrii.s@example.com", PasswordHash = "hashed4", Role = "Buyer" },
                new User { Id = 5, FullName = "Natalia Melnyk", Email = "natalia.m@example.com", PasswordHash = "hashed5", Role = "Seller" },
                new User { Id = 6, FullName = "Oleksii Hnatiuk", Email = "oleksii.g@example.com", PasswordHash = "hashed6", Role = "Admin" },
                new User { Id = 7, FullName = "Tetiana Savchuk", Email = "tetiana.s@example.com", PasswordHash = "hashed7", Role = "Buyer" },
                new User { Id = 8, FullName = "Yurii Lysenko", Email = "yurii.l@example.com", PasswordHash = "hashed8", Role = "Seller" },
                new User { Id = 9, FullName = "Oksana Kravchuk", Email = "oksana.k@example.com", PasswordHash = "hashed9", Role = "Seller" },
                new User { Id = 10, FullName = "Volodymyr Ostapchuk", Email = "volodymyr.o@example.com", PasswordHash = "hashed10", Role = "Buyer" },
                new User { Id = 11, FullName = "Svitlana Bondar", Email = "svitlana.b@example.com", PasswordHash = "hashed11", Role = "Seller" },
                new User { Id = 12, FullName = "Maxym Kozak", Email = "max.kozak@example.com", PasswordHash = "hashed12", Role = "Buyer" },
                new User { Id = 13, FullName = "Iryna Sereda", Email = "iryna.s@example.com", PasswordHash = "hashed13", Role = "Seller" },
                new User { Id = 14, FullName = "Roman Dubenko", Email = "roman.d@example.com", PasswordHash = "hashed14", Role = "Buyer" },
                new User { Id = 15, FullName = "Kateryna Yushchenko", Email = "katia.y@example.com", PasswordHash = "hashed15", Role = "Seller" }
            );

            modelBuilder.Entity<Property>().HasData(
                new Property { Id = 1, Title = "Modern City Apartment", Address = "Kyiv, Independence Ave. 10", Price = 85000, Description = "2-bedroom apartment in city center", PropertyTypeId = 1, OwnerId = 1, CreatedAt = new DateTime(2024, 6, 23) },
                new Property { Id = 2, Title = "Family Suburban House", Address = "Lviv, Zelenyi District, House 4", Price = 125000, Description = "Spacious house with garden", PropertyTypeId = 2, OwnerId = 2, CreatedAt = new DateTime(2024, 6, 23) },
                new Property { Id = 3, Title = "Office Space in Business Center", Address = "Dnipro, Central Ave. 15", Price = 150000, Description = "Fully equipped office floor", PropertyTypeId = 3, OwnerId = 3, CreatedAt = new DateTime(2024, 6, 23) },
                new Property { Id = 4, Title = "Countryside Land Plot", Address = "Vinnytsia region, Stepova St.", Price = 18000, Description = "10 ares for private construction", PropertyTypeId = 4, OwnerId = 4, CreatedAt = new DateTime(2024, 6, 23) },
                new Property { Id = 5, Title = "Studio Apartment for Students", Address = "Chernivtsi, Universytetska St. 8", Price = 60000, Description = "Compact, affordable studio", PropertyTypeId = 1, OwnerId = 5, CreatedAt = new DateTime(2024, 6, 23) },
                new Property { Id = 6, Title = "Renovated Rural House", Address = "Ivano-Frankivsk region, Dubova St. 22", Price = 70000, Description = "Cozy cottage with fireplace", PropertyTypeId = 2, OwnerId = 6, CreatedAt = new DateTime(2024, 6, 23) },
                new Property { Id = 7, Title = "Retail Shopfront", Address = "Poltava, Market Square", Price = 98000, Description = "Ground floor store, high foot traffic", PropertyTypeId = 3, OwnerId = 7, CreatedAt = new DateTime(2024, 6, 23) },
                new Property { Id = 8, Title = "Secluded Village Land", Address = "Zhytomyr region, Kvitkova St.", Price = 15500, Description = "Ideal for eco-house or garden", PropertyTypeId = 4, OwnerId = 8, CreatedAt = new DateTime(2024, 6, 23) },
                new Property { Id = 9, Title = "Loft Apartment with Balcony", Address = "Kharkiv, Sumska St. 45", Price = 89000, Description = "Open space layout, modern style", PropertyTypeId = 1, OwnerId = 9, CreatedAt = new DateTime(2024, 6, 23) },
                new Property { Id = 10, Title = "Two-Storey Townhouse", Address = "Ternopil, Nova St. 19", Price = 110000, Description = "Garage and small backyard included", PropertyTypeId = 2, OwnerId = 10, CreatedAt = new DateTime(2024, 6, 23) },
                new Property { Id = 11, Title = "Warehouse with Dock Access", Address = "Odesa Port Zone", Price = 130000, Description = "Industrial storage, truck access", PropertyTypeId = 3, OwnerId = 11, CreatedAt = new DateTime(2024, 6, 23) },
                new Property { Id = 12, Title = "Scenic Land Near River", Address = "Rivne region, Berehova St.", Price = 17000, Description = "Quiet and green surroundings", PropertyTypeId = 4, OwnerId = 12, CreatedAt = new DateTime(2024, 6, 23) },
                new Property { Id = 13, Title = "Luxury Downtown Apartment", Address = "Kyiv, Khreschatyk 21", Price = 200000, Description = "Top floor with elevator", PropertyTypeId = 1, OwnerId = 13, CreatedAt = new DateTime(2024, 6, 23) },
                new Property { Id = 14, Title = "New Brick House", Address = "Cherkasy region, Molodizhna St. 10", Price = 105000, Description = "Modern plan, ready to move in", PropertyTypeId = 2, OwnerId = 14, CreatedAt = new DateTime(2024, 6, 23) },
                new Property { Id = 15, Title = "Cafe Space in Tourist Area", Address = "Lviv Old Town, Rynok Square", Price = 115000, Description = "Historic building with large windows", PropertyTypeId = 3, OwnerId = 15, CreatedAt = new DateTime(2024, 6, 23) }
            );
        }
    }
}
