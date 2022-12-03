using Microsoft.EntityFrameworkCore;

namespace cloudyweb.Models
{
    public class CloudyWeb : DbContext
    {
        public CloudyWeb(DbContextOptions<CloudyWeb> dbContextOptions) : base(dbContextOptions) { }

        public DbSet<Page> Pages { get; set; }
    }
}
