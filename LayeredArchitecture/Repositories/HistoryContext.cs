using LayeredArchitecture.Repositories.Models;

using Microsoft.EntityFrameworkCore;

namespace LayeredArchitecture.Repositories
{
    public class HistoryContext : DbContext
    {
        public HistoryContext(DbContextOptions<HistoryContext> options) : base(options)
        {
        }

        public DbSet<History> Histories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<History>().ToInMemoryQuery(() => Histories);
        }
    }
}