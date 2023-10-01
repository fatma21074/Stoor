using Microsoft.EntityFrameworkCore;
using Stoor.Models;

namespace Stoor.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }    
        public DbSet<Order> orders { get; set; }

    }
}
