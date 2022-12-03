using Microsoft.EntityFrameworkCore;

namespace cloudyweb.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> dbContextOptions) : base(dbContextOptions) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultContainer("CloudyWeb");
            modelBuilder.Entity<Page>().HasPartitionKey(o => o.Id);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Page> Pages { get; set; }
    }
}
