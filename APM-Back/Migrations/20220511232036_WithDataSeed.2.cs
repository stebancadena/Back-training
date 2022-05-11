using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace APM_Back.Migrations
{
    public partial class WithDataSeed2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("1e429b23-acdb-418b-a8f8-fda9952f848f"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("902e6000-f9e1-45cf-8883-98646167b8dd"));

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Description", "ImageUrl", "Price", "ProductCode", "ProductName", "ReleaseDate", "Secret", "StarRating" },
                values: new object[,]
                {
                    { new Guid("ef0938b9-56ce-4d73-8b26-2ce33e96157f"), "Leaf rake with 48-inch wooden handle", "assets/images/leaf_rake.png", 19.95m, "GDN-0011", "Leaf Rake", "March 19, 2018", null, 3.2m },
                    { new Guid("33dee5d6-ea5e-4bb4-94ba-2ee5e29fdfec"), "15 gallon capacity rolling garden cart", "assets/images/garden_cart.png", 32.99m, "GDN-0023", "Garden Cart", "March 18, 2018", null, 4.2m },
                    { new Guid("3f1c8491-ff04-481a-9bb5-b62dab42d6dd"), "Curved claw steel hammer", "assets/images/hammer.png", 8.9m, "TBX-0048", "Hammer", "May 21, 2018", null, 4.8m },
                    { new Guid("2d810566-e92a-450d-a6c3-7bf0bf4ac695"), "15-inch steel blade hand saw", "assets/images/saw.png", 11.55m, "TBX-0022", "Saw", "May 15, 2018", null, 3.7m },
                    { new Guid("23e53b7e-3e3d-4af0-84c5-c91ff5c1a2e5"), "Standard two-button video game controller", "assets/images/xbox-controller.png", 35.95m, "GMG-0042", "Video Game Controller", "October 15, 2018", null, 4.6m },
                    { new Guid("1254335b-c730-4081-964b-5c9faf23d9bc"), "Leaf rake with 48-inch wooden handle", "assets/images/leaf_rake.png", 19.95m, "GDN-0011", "Leaf Rake Copied", "March 19, 2018", null, 3.2m },
                    { new Guid("be8e9481-7a33-441f-9236-0b172f3a3623"), "15 gallon capacity rolling garden cart", "assets/images/garden_cart.png", 32.99m, "GDN-0023", "Garden Cart Copied", "March 18, 2018", null, 4.2m },
                    { new Guid("22e2ac8d-f2c4-4545-8aa6-cdb94bb1f8f7"), "Curved claw steel hammer", "assets/images/hammer.png", 8.9m, "TBX-0048", "Hammer Copied", "May 21, 2018", null, 4.8m },
                    { new Guid("ef0d60d5-c396-40fb-8c1d-e25b8cf0aa08"), "15-inch steel blade hand saw", "assets/images/saw.png", 11.55m, "TBX-0022", "Saw Copied", "May 15, 2018", null, 3.7m },
                    { new Guid("2fae6565-73db-4f06-8135-85aa36807bad"), "Standard two-button video game controller", "assets/images/xbox-controller.png", 35.95m, "GMG-0042", "Video Game Controller Copied", "October 15, 2018", null, 4.6m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("1254335b-c730-4081-964b-5c9faf23d9bc"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("22e2ac8d-f2c4-4545-8aa6-cdb94bb1f8f7"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("23e53b7e-3e3d-4af0-84c5-c91ff5c1a2e5"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("2d810566-e92a-450d-a6c3-7bf0bf4ac695"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("2fae6565-73db-4f06-8135-85aa36807bad"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("33dee5d6-ea5e-4bb4-94ba-2ee5e29fdfec"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("3f1c8491-ff04-481a-9bb5-b62dab42d6dd"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("be8e9481-7a33-441f-9236-0b172f3a3623"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("ef0938b9-56ce-4d73-8b26-2ce33e96157f"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("ef0d60d5-c396-40fb-8c1d-e25b8cf0aa08"));

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Description", "ImageUrl", "Price", "ProductCode", "ProductName", "ReleaseDate", "Secret", "StarRating" },
                values: new object[,]
                {
                    { new Guid("1e429b23-acdb-418b-a8f8-fda9952f848f"), "Leaf rake with 48-inch wooden handle", "assets/images/leaf_rake.png", 19.95m, "GDN-0011", "Leaf Rake", "March 19, 2018", null, 3.2m },
                    { new Guid("902e6000-f9e1-45cf-8883-98646167b8dd"), "15 gallon capacity rolling garden cart", "assets/images/garden_cart.png", 32.99m, "GDN-0023", "Garden Cart", "March 18, 2018", null, 4.2m }
                });
        }
    }
}
