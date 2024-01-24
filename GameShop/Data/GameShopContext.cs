using GameShop.Models;
using Microsoft.EntityFrameworkCore;

namespace GameShop.Data
{
    public class GameShopContext : DbContext
    {

        public GameShopContext(DbContextOptions<GameShopContext> options) : base(options)
        {

        }

        public DbSet<Game> Games { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Producer> Producers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Game>()
                .Property(g => g.Price)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Order>()
                .Property(o => o.OrderCost)
                .HasColumnType("decimal(18,2)");
        }
    }
}