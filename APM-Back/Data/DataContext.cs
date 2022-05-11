using Microsoft.EntityFrameworkCore;
using System;

namespace APM_Back.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseSerialColumns();

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    ProductId = Guid.NewGuid(),
                    ProductName = "Leaf Rake",
                    ProductCode = "GDN-0011",
                    ReleaseDate = "March 19, 2018",
                    Description = "Leaf rake with 48-inch wooden handle",
                    Price = Convert.ToDecimal(19.95),
                    StarRating = Convert.ToDecimal(3.2),
                    ImageUrl = "assets/images/leaf_rake.png",
                } ,
                new Product
                {
                    ProductId = Guid.NewGuid(),
                    ProductName= "Garden Cart",
                    ProductCode= "GDN-0023",
                    ReleaseDate= "March 18, 2018",
                    Description= "15 gallon capacity rolling garden cart",
                    Price = Convert.ToDecimal(32.99),
                    StarRating = Convert.ToDecimal(4.2),
                    ImageUrl= "assets/images/garden_cart.png",
                } ,
                new Product
                {
                    ProductId = Guid.NewGuid(),
                    ProductName = "Hammer",
                    ProductCode = "TBX-0048",
                    ReleaseDate = "May 21, 2018",
                    Description = "Curved claw steel hammer",
                    Price = Convert.ToDecimal(8.9),
                    StarRating = Convert.ToDecimal(4.8),
                    ImageUrl = "assets/images/hammer.png",
                },
                new Product
                {
                    ProductId = Guid.NewGuid(),
                    ProductName = "Saw",
                    ProductCode = "TBX-0022",
                    ReleaseDate = "May 15, 2018",
                    Description = "15-inch steel blade hand saw",
                    Price = Convert.ToDecimal(11.55),
                    StarRating = Convert.ToDecimal(3.7),
                    ImageUrl = "assets/images/saw.png",
                },
                new Product
                {
                    ProductId = Guid.NewGuid(),
                    ProductName = "Video Game Controller",
                    ProductCode = "GMG-0042",
                    ReleaseDate = "October 15, 2018",
                    Description = "Standard two-button video game controller",
                    Price = Convert.ToDecimal(35.95),
                    StarRating = Convert.ToDecimal(4.6),
                    ImageUrl = "assets/images/xbox-controller.png",
                } ,
                new Product
                {
                    ProductId = Guid.NewGuid(),
                    ProductName = "Leaf Rake Copied",
                    ProductCode = "GDN-0011",
                    ReleaseDate = "March 19, 2018",
                    Description = "Leaf rake with 48-inch wooden handle",
                    Price = Convert.ToDecimal(19.95),
                    StarRating = Convert.ToDecimal(3.2),
                    ImageUrl = "assets/images/leaf_rake.png",
                },
                new Product
                {
                    ProductId = Guid.NewGuid(),
                    ProductName = "Garden Cart Copied",
                    ProductCode = "GDN-0023",
                    ReleaseDate = "March 18, 2018",
                    Description = "15 gallon capacity rolling garden cart",
                    Price = Convert.ToDecimal(32.99),
                    StarRating = Convert.ToDecimal(4.2),
                    ImageUrl = "assets/images/garden_cart.png",
                },
                new Product
                {
                    ProductId = Guid.NewGuid(),
                    ProductName = "Hammer Copied",
                    ProductCode = "TBX-0048",
                    ReleaseDate = "May 21, 2018",
                    Description = "Curved claw steel hammer",
                    Price = Convert.ToDecimal(8.9),
                    StarRating = Convert.ToDecimal(4.8),
                    ImageUrl = "assets/images/hammer.png",
                },
                new Product
                {
                    ProductId = Guid.NewGuid(),
                    ProductName = "Saw Copied",
                    ProductCode = "TBX-0022",
                    ReleaseDate = "May 15, 2018",
                    Description = "15-inch steel blade hand saw",
                    Price = Convert.ToDecimal(11.55),
                    StarRating = Convert.ToDecimal(3.7),
                    ImageUrl = "assets/images/saw.png",
                },
                new Product
                {
                    ProductId = Guid.NewGuid(),
                    ProductName = "Video Game Controller Copied",
                    ProductCode = "GMG-0042",
                    ReleaseDate = "October 15, 2018",
                    Description = "Standard two-button video game controller",
                    Price = Convert.ToDecimal(35.95),
                    StarRating = Convert.ToDecimal(4.6),
                    ImageUrl = "assets/images/xbox-controller.png",
                });
        }

        public DbSet<Product> Products { get; set; }
    }
}
