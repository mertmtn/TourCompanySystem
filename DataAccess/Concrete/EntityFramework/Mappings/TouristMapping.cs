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
           
            builder.Property(t => t.BirthDate).IsRequired();
            
            builder.Property(t => t.NationalityId).IsRequired();
            builder.HasOne(u => u.Nationality).WithMany(r => r.Tourists).HasForeignKey(u => u.NationalityId);

            builder.Property(t => t.CountryId).IsRequired();
            builder.HasOne(u => u.Country).WithMany(r => r.Tourists).HasForeignKey(u => u.CountryId);

            builder.HasMany(t => t.Tours).WithMany(t => t.Tourists);
            builder.HasOne(u => u.Invoice).WithOne(r => r.Tourist).HasForeignKey<Invoice>(u => u.TouristId);
        }
    }
}
