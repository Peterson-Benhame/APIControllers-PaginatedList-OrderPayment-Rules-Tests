using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProvaPub.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Alonzo Volkman" },
                    { 2, "Allan Greenfelder" },
                    { 3, "Irving Huels" },
                    { 4, "Jane Balistreri" },
                    { 5, "Edward Cole" },
                    { 6, "Susan Nader" },
                    { 7, "Pete Goodwin" },
                    { 8, "Veronica Bartoletti" },
                    { 9, "Ron Fadel" },
                    { 10, "Angelina Greenfelder" },
                    { 11, "Evelyn Zieme" },
                    { 12, "Alberto Schuppe" },
                    { 13, "Marian Streich" },
                    { 14, "Roland Windler" },
                    { 15, "Lee Ryan" },
                    { 16, "Megan Boyer" },
                    { 17, "Marcia Homenick" },
                    { 18, "Cedric Upton" },
                    { 19, "Vicki Ferry" },
                    { 20, "Irving Cronin" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Tasty Steel Car" },
                    { 2, "Handmade Soft Mouse" },
                    { 3, "Handcrafted Cotton Salad" },
                    { 4, "Fantastic Steel Soap" },
                    { 5, "Incredible Concrete Computer" },
                    { 6, "Licensed Metal Tuna" },
                    { 7, "Tasty Fresh Pizza" },
                    { 8, "Incredible Frozen Ball" },
                    { 9, "Refined Rubber Salad" },
                    { 10, "Rustic Metal Tuna" },
                    { 11, "Gorgeous Wooden Table" },
                    { 12, "Sleek Steel Bacon" },
                    { 13, "Unbranded Plastic Chicken" },
                    { 14, "Rustic Steel Pants" },
                    { 15, "Rustic Cotton Shirt" },
                    { 16, "Sleek Wooden Sausages" },
                    { 17, "Incredible Fresh Chips" },
                    { 18, "Handcrafted Frozen Bacon" },
                    { 19, "Handcrafted Metal Chair" },
                    { 20, "Generic Wooden Towels" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
