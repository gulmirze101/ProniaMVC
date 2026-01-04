using Azure;
using Microsoft.EntityFrameworkCore;
using Pronia.Models;

namespace Pronia.Contexts
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions options):base(options)
        {

        }

        public DbSet<Slider> Sliders { get; set; }
        public DbSet<ServiceFeature> ServiceFeatures { get; set; }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<ProductTag> ProductTags { get; set; }
    }
}
