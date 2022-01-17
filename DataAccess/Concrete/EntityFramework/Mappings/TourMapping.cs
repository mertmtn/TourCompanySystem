using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess
{
    public class TourMapping : IEntityTypeConfiguration<Tour>
    {
        public void Configure(EntityTypeBuilder<Tour> builder)
        {
            builder.HasKey(p => p.TourId);
            builder.Property(p => p.TourId).ValueGeneratedOnAdd();
            builder.Property(p => p.Name).HasMaxLength(150).IsRequired();
            builder.Property(p => p.TourDate).IsRequired();
            builder.HasMany(t => t.Tourists).WithMany(t => t.Tours);
            builder.HasMany(t => t.Places).WithMany(t => t.Tours);
            builder.HasOne(u => u.Guide).WithOne(r => r.Tour);
        }
    }
}