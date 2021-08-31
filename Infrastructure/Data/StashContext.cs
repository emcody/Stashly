using System.Reflection;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class StashContext : DbContext
    {
        public StashContext(DbContextOptions<StashContext> options) : base(options)
        {

        }

        public DbSet<Item> Items { get; set; }

        public DbSet<Stash> Stashes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}