using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.EntityFramework.Mappings
{
    public class GuideMapping : IEntityTypeConfiguration<Guide>
    {
        public void Configure(EntityTypeBuilder<Guide> builder)
        {
            builder.HasKey(g => g.GuideId);
            builder.Property(g => g.GuideId).ValueGeneratedOnAdd();
            builder.Property(g => g.Name).HasMaxLength(20).IsRequired();
            builder.Property(g => g.Surname).HasMaxLength(40).IsRequired();
            builder.HasMany(g => g.Languages).WithMany(g => g.Guides);
        }
    }
}
