using Microsoft.EntityFrameworkCore;

namespace netcore1stapi.Models
{
    public class WallContext : DbContext
    {
        public WallContext(DbContextOptions<WallContext> options) : base(options)
        {
        }
        public DbSet<Item> WallItems { get; set; }
    }    
}