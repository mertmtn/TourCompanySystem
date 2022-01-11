using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.EntityFramework.Mappings
{
    public class CountryMapping : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.HasKey(c=> c.CountryId);
            builder.Property(c => c.CountryId).ValueGeneratedOnAdd();
            builder.Property(c => c.Name).HasMaxLength(50).IsRequired();
        }
    }
}