using BookShoppingUI.Models;
using Microsoft.EntityFrameworkCore;

namespace BookShoppingUI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Book> Book { get; set; }
        public DbSet<Genre> Genre { get; set; }
        public DbSet<Order> MyProperty { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<OrderStatus> OrderStatus { get; set; }
        public DbSet<CartDetail> CartDetail { get; set; }
        public DbSet<shoppingCart> shoppingCarts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            var seedGenre = new List<Genre>()
            {
                new Genre
                {
                    Id = 1,
                    GenreName = "Advanture"
                },
                new Genre
                {
                    Id = 2,
                    GenreName = "Science fiction"
                },
                new Genre
                {
                    Id = 3,
                    GenreName = "Romance"
                },
                new Genre
                {
                    Id = 4,
                    GenreName = "Horror"
                },

            };

            builder.Entity<Genre>().HasData(seedGenre);
            base.OnModelCreating(builder);
        }

    }
}

