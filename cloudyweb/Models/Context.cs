using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace cloudyweb.Models
{
    public class Context : DbContext
    {
        private readonly IConfiguration configuration;

        public Context(DbContextOptions<Context> dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
        {
            this.configuration = configuration;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultContainer(configuration["CosmosContainer"] ?? throw new Exception("CosmosContainer needed"));

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
