using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BuyAndRead.Models
{
    public sealed class BuyAndReadDbContext : DbContext
    {
        
        public BuyAndReadDbContext(DbContextOptions<BuyAndReadDbContext> options) : base(options)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

       
        
        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }
        
        public DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            /*optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=user;Username=postgres;" +
                                     "Password=11111");
            base.OnConfiguring(optionsBuilder); */
            if (optionsBuilder.IsConfigured)
                return;
            var config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).
                AddJsonFile("./appsettings.json").Build();
            var connectString = config.GetConnectionString("BuyAndReadDbContext");
            optionsBuilder.UseNpgsql(connectString).EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1, Promocode = new Guid("b77d409a-10cd-4a47-8e94-b0cd0ab50aa1") 
                });
            
            modelBuilder.Entity<Order>()
                .HasOne(o => o.User)
                .WithMany(u => u.Orders);

            modelBuilder.Entity<BookOrder>()
                .HasKey(o => new {o.BookId, o.OrderId});
            modelBuilder.Entity<BookOrder>()
                .HasOne(bo => bo.Book)
                .WithMany(b => b.BookOrders)
                .HasForeignKey(bo => bo.BookId);
            modelBuilder.Entity<BookOrder>()
                .HasOne(bo => bo.Order)
                .WithMany(o => o.BookOrders)
                .HasForeignKey(bo => bo.OrderId);
        }
        
    }
}