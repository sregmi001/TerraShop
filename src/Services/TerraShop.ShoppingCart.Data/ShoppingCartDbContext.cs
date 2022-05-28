using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TerraShop.Domain.Shared;
using TerraShop.Domain.ShoppingCart;

namespace TerraShop.ShoppingCart.Data
{
    public class ShoppingCartDbContext : DbContext
    {
        public ShoppingCartDbContext(DbContextOptions<ShoppingCartDbContext> options) : base(options)
        {
        }
        public DbSet<Basket> Baskets { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var productIdConverter = new ValueConverter<ProductId, Guid>(
               p => p.Value,
               p => new ProductId(p));

            var visitorIdConverter = new ValueConverter<VisitorId, Guid>(
               p => p.Value,
               p => new VisitorId(p));

            var basketIdConverter = new ValueConverter<BasketId, Guid>(
                   p => p.Value,
                   p => new BasketId(p));

            var basketItemIdConverter = new ValueConverter<BasketItemId, Guid>(
                   p => p.Value,
                   p => new BasketItemId(p));

            modelBuilder.Entity<Basket>().HasKey(b => b.Id);
            modelBuilder.Entity<Basket>().Property(b => b.Id).HasConversion(basketIdConverter);
            modelBuilder.Entity<Basket>().Property(b => b.VisitorId).HasConversion(visitorIdConverter);

            modelBuilder.Entity<BasketItem>().HasKey(b => b.Id);
            modelBuilder.Entity<BasketItem>().Property(b => b.Id).HasConversion(basketItemIdConverter);
            modelBuilder.Entity<BasketItem>().Property(b => b.ProductId).HasConversion(productIdConverter);
            modelBuilder.Entity<BasketItem>().Property(b => b.BasketId).HasConversion(basketIdConverter);            
            modelBuilder.Entity<BasketItem>().OwnsOne(b => b.UnitPrice);
        }
    }
}
