using Blogs.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Blogs.Infrastructure
{
    public class BlogsDbContext : DbContext
    {
        public BlogsDbContext( DbContextOptions options ) : base( options )
        {
        }

        protected override void OnModelCreating( ModelBuilder modelBuilder )
        {
            modelBuilder.ApplyConfiguration( new UserConfiguration() );
        }
    }
}
