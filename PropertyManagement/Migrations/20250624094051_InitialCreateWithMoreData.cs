using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PropertyManagement.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreateWithMoreData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Address", "Description", "Price", "Title" },
                values: new object[] { "Kyiv, Independence Ave. 10", "2-bedroom apartment in city center", 85000m, "Modern City Apartment" });

            migrationBuilder.InsertData(
                table: "PropertyTypes",
                columns: new[] { "Id", "Name" },
                values: new object[] { 4, "Land Plot" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Email", "FullName", "PasswordHash" },
                values: new object[] { "olena.t@example.com", "Olena Tkachenko", "hashed1" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FullName", "PasswordHash", "Role" },
                values: new object[,]
                {
                    { 2, "ivan.p@example.com", "Ivan Petrenko", "hashed2", "Buyer" },
                    { 3, "maria.k@example.com", "Maria Koval", "hashed3", "Seller" },
                    { 4, "andrii.s@example.com", "Andrii Shevchenko", "hashed4", "Buyer" },
                    { 5, "natalia.m@example.com", "Natalia Melnyk", "hashed5", "Seller" },
                    { 6, "oleksii.g@example.com", "Oleksii Hnatiuk", "hashed6", "Admin" },
                    { 7, "tetiana.s@example.com", "Tetiana Savchuk", "hashed7", "Buyer" },
                    { 8, "yurii.l@example.com", "Yurii Lysenko", "hashed8", "Seller" },
                    { 9, "oksana.k@example.com", "Oksana Kravchuk", "hashed9", "Seller" },
                    { 10, "volodymyr.o@example.com", "Volodymyr Ostapchuk", "hashed10", "Buyer" },
                    { 11, "svitlana.b@example.com", "Svitlana Bondar", "hashed11", "Seller" },
                    { 12, "max.kozak@example.com", "Maxym Kozak", "hashed12", "Buyer" },
                    { 13, "iryna.s@example.com", "Iryna Sereda", "hashed13", "Seller" },
                    { 14, "roman.d@example.com", "Roman Dubenko", "hashed14", "Buyer" },
                    { 15, "katia.y@example.com", "Kateryna Yushchenko", "hashed15", "Seller" }
                });

            migrationBuilder.InsertData(
                table: "Properties",
                columns: new[] { "Id", "Address", "CreatedAt", "Description", "OwnerId", "Price", "PropertyTypeId", "Title" },
                values: new object[,]
                {
                    { 2, "Lviv, Zelenyi District, House 4", new DateTime(2024, 6, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Spacious house with garden", 2, 125000m, 2, "Family Suburban House" },
                    { 3, "Dnipro, Central Ave. 15", new DateTime(2024, 6, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fully equipped office floor", 3, 150000m, 3, "Office Space in Business Center" },
                    { 4, "Vinnytsia region, Stepova St.", new DateTime(2024, 6, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "10 ares for private construction", 4, 18000m, 4, "Countryside Land Plot" },
                    { 5, "Chernivtsi, Universytetska St. 8", new DateTime(2024, 6, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Compact, affordable studio", 5, 60000m, 1, "Studio Apartment for Students" },
                    { 6, "Ivano-Frankivsk region, Dubova St. 22", new DateTime(2024, 6, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cozy cottage with fireplace", 6, 70000m, 2, "Renovated Rural House" },
                    { 7, "Poltava, Market Square", new DateTime(2024, 6, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ground floor store, high foot traffic", 7, 98000m, 3, "Retail Shopfront" },
                    { 8, "Zhytomyr region, Kvitkova St.", new DateTime(2024, 6, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ideal for eco-house or garden", 8, 15500m, 4, "Secluded Village Land" },
                    { 9, "Kharkiv, Sumska St. 45", new DateTime(2024, 6, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Open space layout, modern style", 9, 89000m, 1, "Loft Apartment with Balcony" },
                    { 10, "Ternopil, Nova St. 19", new DateTime(2024, 6, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Garage and small backyard included", 10, 110000m, 2, "Two-Storey Townhouse" },
                    { 11, "Odesa Port Zone", new DateTime(2024, 6, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Industrial storage, truck access", 11, 130000m, 3, "Warehouse with Dock Access" },
                    { 12, "Rivne region, Berehova St.", new DateTime(2024, 6, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Quiet and green surroundings", 12, 17000m, 4, "Scenic Land Near River" },
                    { 13, "Kyiv, Khreschatyk 21", new DateTime(2024, 6, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Top floor with elevator", 13, 200000m, 1, "Luxury Downtown Apartment" },
                    { 14, "Cherkasy region, Molodizhna St. 10", new DateTime(2024, 6, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Modern plan, ready to move in", 14, 105000m, 2, "New Brick House" },
                    { 15, "Lviv Old Town, Rynok Square", new DateTime(2024, 6, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Historic building with large windows", 15, 115000m, 3, "Cafe Space in Tourist Area" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "PropertyTypes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Address", "Description", "Price", "Title" },
                values: new object[] { "Lviv, Franka St.", "2-bedroom, cozy, balcony", 55000m, "Modern Apartment" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Email", "FullName", "PasswordHash" },
                values: new object[] { "ivan@example.com", "Ivan Petrenko", "hashed" });
        }
    }
}
