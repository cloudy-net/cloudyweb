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
            modelBuilder.Entity<SiteSettings>().HasPartitionKey(o => o.Id);
            modelBuilder.Entity<StartPage>().HasPartitionKey(o => o.Id);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Page> Pages { get; set; }
        public DbSet<SiteSettings> SiteSettings { get; set; }
        public DbSet<StartPage> StartPage { get; set; }
    }
}
