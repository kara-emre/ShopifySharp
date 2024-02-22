using Microsoft.EntityFrameworkCore;
using ShopifySharp.Identity.Domain.Entities;

namespace ShopifySharp.Identity.Infrastructure
{
    public class ShopifySharpDbContext : DbContext
    {
        public DbSet<User> User { get; set; }
        public ShopifySharpDbContext(DbContextOptions<ShopifySharpDbContext> options) : base(options)
        {
        }
        // DbContext sınıfınızın özellikleri ve yapılandırması buraya gelecek
    }
}