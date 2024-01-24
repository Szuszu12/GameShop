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
        //public DbSet<GameOrder> GameOrders { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Producer> Producers { get; set; }
        //public DbSet<GameCategory> GameCategories { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Game>()
                .Property(g => g.Price)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Order>()
                .Property(o => o.OrderCost)
                .HasColumnType("decimal(18,2)");

            //modelBuilder.Entity<GameOrder>()
            //    .HasKey(go => new { go.GameId, go.OrderId });
            //modelBuilder.Entity<GameOrder>()
            //    .HasOne(g => g.Game)
            //    .WithMany(go => go.GameOrders)
            //    .HasForeignKey(g => g.GameId);
            //modelBuilder.Entity<GameOrder>()
            //    .HasOne(g => g.Order)
            //    .WithMany(go => go.GameOrders)
            //    .HasForeignKey(o => o.OrderId);

            //modelBuilder.Entity<GameCategory>()
            //    .HasKey(gc => new { gc.GameId, gc.CategoryId });

            //modelBuilder.Entity<GameCategory>()
            //    .HasOne(gc => gc.Game)
            //    .WithMany(g => g.GameCategories)
            //    .HasForeignKey(gc => gc.GameId);

            //modelBuilder.Entity<GameCategory>()
            //    .HasOne(gc => gc.Category)
            //    .WithMany(c => c.GameCategories)
            //    .HasForeignKey(gc => gc.CategoryId);

        }
    }
}