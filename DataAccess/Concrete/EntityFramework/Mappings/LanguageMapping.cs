using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.EntityFramework.Mappings
{
    public class LanguageMapping : IEntityTypeConfiguration<Language>
    {
        public void Configure(EntityTypeBuilder<Language> builder)
        {
            builder.HasKey(p => p.LanguageId);
            builder.Property(p => p.LanguageId).ValueGeneratedOnAdd();
            builder.Property(p => p.Name).HasMaxLength(20).IsRequired();            
        }
    }
}
