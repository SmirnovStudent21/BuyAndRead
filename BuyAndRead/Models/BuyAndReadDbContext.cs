using Microsoft.EntityFrameworkCore;

namespace BuyAndRead.Models
{
    public sealed class BuyAndReadDbContext : DbContext
    {
        
        public BuyAndReadDbContext(DbContextOptions<BuyAndReadDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

       

        public DbSet<Book> Books { get; set; }
        public static DbSet<User> Users { get; set; }
        
        public DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=user;Username=postgres;Password=password");
            base.OnConfiguring(optionsBuilder);
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                .HasOne(o => o.User)
                .WithMany(u => u.Orders);

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1, Promocode = "b77d409a-10cd-4a47-8e94-b0cd0ab50aa1"
                });

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