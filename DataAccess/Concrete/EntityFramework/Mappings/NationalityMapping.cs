using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.EntityFramework.Mappings
{
    public class NationalityMapping : IEntityTypeConfiguration<Nationality>
    {
        public void Configure(EntityTypeBuilder<Nationality> builder)
        {
            builder.HasKey(n => n.NationalityId);
            builder.Property(n => n.NationalityId).ValueGeneratedOnAdd();
            builder.Property(n => n.Name).HasMaxLength(50).IsRequired();
          
        }
    }
}