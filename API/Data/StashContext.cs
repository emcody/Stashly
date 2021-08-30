using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class StashContext : DbContext
    {
        public StashContext(DbContextOptions<StashContext> options) : base(options)
        {

        }

        public DbSet<Item> Items { get; set; }
    }
}