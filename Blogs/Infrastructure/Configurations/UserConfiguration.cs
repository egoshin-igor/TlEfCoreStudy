using Blogs.Application.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blogs.Infrastructure.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure( EntityTypeBuilder<Author> builder )
        {
            builder.HasKey( x => x.Id );

            builder.Property( x => x.Name ).HasMaxLength( 200 );
        }
    }
}
