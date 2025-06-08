using CourseWork.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CourseWork.Data
{
    public class AppDBContent : DbContext
    {
        public AppDBContent(DbContextOptions<AppDBContent> options) : base(options) 
        { 

        }

        public DbSet<Game> Games { get; set; }
        public DbSet<Category> Categories { get; set; } 

        public DbSet<ShopGamesItem> ShopGamesItem { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderDetail> OrderDetail { get; set; }
    }
}
