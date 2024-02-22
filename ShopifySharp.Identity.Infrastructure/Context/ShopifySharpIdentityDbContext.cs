using Microsoft.EntityFrameworkCore;
using ShopifySharp.Identity.Domain.Entities;

namespace ShopifySharp.Identity.Infrastructure.Context
{
    public class ShopifySharpIdentityDbContext : DbContext
    {
        public DbSet<User> User { get; set; }
        public ShopifySharpIdentityDbContext(DbContextOptions<ShopifySharpIdentityDbContext> options) : base(options)
        {
        }
        // DbContext sınıfınızın özellikleri ve yapılandırması buraya gelecek
    }
}