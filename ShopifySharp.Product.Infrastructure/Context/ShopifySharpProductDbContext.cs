using Bogus;
using Microsoft.EntityFrameworkCore;
using ShopifySharp.Product.Domain.Entities;

namespace ShopifySharp.Product.Infrastructure.Context
{
    public class ShopifySharpProductDbContext : DbContext
    {
        public DbSet<Products> Product { get; set; }
        public DbSet<Categorys> Category { get; set; }

        public ShopifySharpProductDbContext(DbContextOptions<ShopifySharpProductDbContext> options) : base(options)
        {
        }
        // DbContext sınıfınızın özellikleri ve yapılandırması buraya gelecek

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var fakerCategory = new Faker<Categorys>()
                .RuleFor(p => p.Id, f => f.Random.Guid())
                .RuleFor(p => p.Name, f => f.Commerce.Categories(1)[0])
                .RuleFor(p => p.IsActive, f => true);

            var categories = fakerCategory.Generate(5); // 5 tane kategori oluşturuyoruz

            var faker = new Faker<Products>()
                .RuleFor(p => p.Id, f => f.Random.Guid())
                .RuleFor(p => p.Name, f => f.Commerce.ProductName())
                .RuleFor(p => p.Price, f => f.Random.Decimal(1, 1000))
                .RuleFor(p => p.CategoryId, f => f.PickRandom(categories).Id) // Her bir ürüne rastgele bir kategori atıyoruz
                .RuleFor(p => p.IsActive, f => true);

            var products = faker.Generate(1000); // 1000 tane ürün oluşturuyoruz

            modelBuilder.Entity<Categorys>().HasData(categories);
            modelBuilder.Entity<Products>().HasData(products);

        }
    }
}