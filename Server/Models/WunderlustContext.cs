using Microsoft.EntityFrameworkCore;
namespace Server.Models
{
    public class WunderlustContext : DbContext
    {
        public WunderlustContext(DbContextOptions<WunderlustContext> options) : base(options) {}
        public DbSet<UserItem> UserItems { get; set;} = null!;
    }
}