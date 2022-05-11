using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace APM_Back.Migrations
{
    public partial class WithDataSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Description", "ImageUrl", "Price", "ProductCode", "ProductName", "ReleaseDate", "Secret", "StarRating" },
                values: new object[,]
                {
                    { new Guid("1e429b23-acdb-418b-a8f8-fda9952f848f"), "Leaf rake with 48-inch wooden handle", "assets/images/leaf_rake.png", 19.95m, "GDN-0011", "Leaf Rake", "March 19, 2018", null, 3.2m },
                    { new Guid("902e6000-f9e1-45cf-8883-98646167b8dd"), "15 gallon capacity rolling garden cart", "assets/images/garden_cart.png", 32.99m, "GDN-0023", "Garden Cart", "March 18, 2018", null, 4.2m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("1e429b23-acdb-418b-a8f8-fda9952f848f"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("902e6000-f9e1-45cf-8883-98646167b8dd"));
        }
    }
}
