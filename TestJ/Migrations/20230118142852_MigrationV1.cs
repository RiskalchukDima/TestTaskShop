using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TestJ.Migrations
{
    /// <inheritdoc />
    public partial class MigrationV1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RegDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Art = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(5,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sale",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nmr = table.Column<int>(type: "int", nullable: false),
                    SaleDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SaleAmount = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sale", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sale_Client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SaleItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SaleId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SaleItem_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SaleItem_Sale_SaleId",
                        column: x => x.SaleId,
                        principalTable: "Sale",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Client",
                columns: new[] { "Id", "BirthDate", "Fio", "RegDate" },
                values: new object[,]
                {
                    { 1, new DateTime(1980, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tom", new DateTime(2020, 12, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(1983, 11, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alice", new DateTime(2019, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(1975, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sam", new DateTime(2020, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "Art", "Category", "Name", "Price" },
                values: new object[,]
                {
                    { 11, "112", "Fruit", "Orange", 12.60m },
                    { 12, "113", "Meal", "Egg", 6.70m },
                    { 13, "114", "Fruit", "Banana", 8m }
                });

            migrationBuilder.InsertData(
                table: "Sale",
                columns: new[] { "Id", "ClientId", "Nmr", "SaleAmount", "SaleDate" },
                values: new object[,]
                {
                    { 31, 1, 3331, 133.90m, new DateTime(2023, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 32, 1, 3332, 78.00m, new DateTime(2023, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 33, 2, 3333, 242.60m, new DateTime(2023, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 34, 3, 3334, 440m, new DateTime(2023, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "SaleItem",
                columns: new[] { "Id", "Count", "ProductId", "SaleId" },
                values: new object[,]
                {
                    { 311, 5, 11, 31 },
                    { 312, 7, 12, 31 },
                    { 313, 3, 13, 31 },
                    { 321, 3, 11, 32 },
                    { 322, 6, 12, 32 },
                    { 331, 11, 11, 33 },
                    { 332, 13, 13, 33 },
                    { 341, 55, 13, 34 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sale_ClientId",
                table: "Sale",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleItem_ProductId",
                table: "SaleItem",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleItem_SaleId",
                table: "SaleItem",
                column: "SaleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SaleItem");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Sale");

            migrationBuilder.DropTable(
                name: "Client");
        }
    }
}
