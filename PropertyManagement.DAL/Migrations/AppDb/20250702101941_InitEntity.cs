using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PropertyManagement.DAL.Migrations.AppDb
{
    /// <inheritdoc />
    public partial class InitEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PropertyTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FullName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: false),
                    Role = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Properties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    PropertyTypeId = table.Column<int>(type: "integer", nullable: false),
                    OwnerId = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Properties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Properties_PropertyTypes_PropertyTypeId",
                        column: x => x.PropertyTypeId,
                        principalTable: "PropertyTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Properties_Users_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "PropertyTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Apartment" },
                    { 2, "House" },
                    { 3, "Commercial" },
                    { 4, "Land Plot" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FullName", "PasswordHash", "Role" },
                values: new object[,]
                {
                    { 1, "olena.t@example.com", "Olena Tkachenko", "hashed1", "Seller" },
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
                    { 1, "Kyiv, Independence Ave. 10", new DateTime(2024, 6, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "2-bedroom apartment in city center", 1, 85000m, 1, "Modern City Apartment" },
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

            migrationBuilder.CreateIndex(
                name: "IX_Properties_OwnerId",
                table: "Properties",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Properties_PropertyTypeId",
                table: "Properties",
                column: "PropertyTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Properties");

            migrationBuilder.DropTable(
                name: "PropertyTypes");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
