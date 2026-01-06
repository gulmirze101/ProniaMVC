using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Pronia.Configurations
{
    public class TagConfiguration
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.HasMany(x => x.ProductTags).WithOne(x => x.Tag).HasForeignKey(x => x.TagId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
