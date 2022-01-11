using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.EntityFramework.Mappings
{
    public class TouristMapping : IEntityTypeConfiguration<Tourist>
    {
        public void Configure(EntityTypeBuilder<Tourist> builder)
        {
            builder.HasKey(t => t.TouristId);
            builder.Property(t => t.TouristId).ValueGeneratedOnAdd();
            builder.Property(t => t.Name).HasMaxLength(20).IsRequired();
            builder.Property(t => t.Surname).HasMaxLength(40).IsRequired();
            builder.Property(t => t.Gender).IsRequired();
            builder.Property(t => t.CountryId).IsRequired();
            builder.Property(t => t.BirthDate).IsRequired();
            builder.Property(t => t.NationalityId).IsRequired();
        }
    }
}
