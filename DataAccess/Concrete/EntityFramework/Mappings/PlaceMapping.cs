using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.EntityFramework.Mappings
{
    public class PlaceMapping : IEntityTypeConfiguration<Place>
    {
        public void Configure(EntityTypeBuilder<Place> builder)
        {
            builder.HasKey(p => p.PlaceId);
            builder.Property(p => p.PlaceId).ValueGeneratedOnAdd();
            builder.Property(p => p.Name).HasMaxLength(30).IsRequired();
            builder.HasMany(t => t.Tours).WithMany(t => t.Places);
        }
    }
}
