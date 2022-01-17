using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess
{
    public class InvoiceMapping : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder.HasKey(x => x.InvoiceNo);
            builder.Property(x => x.InvoiceNo).ValueGeneratedNever();

            builder.Property(t => t.InvoiceDate).IsRequired();

            builder.Property(t => t.TouristId).IsRequired();
            //builder.HasOne(u => u.Tourist).WithOne(r => r.Invoice).HasForeignKey<Tourist>(x => x.TouristId);
        }
    }

    public class InvoiceDetailMapping : IEntityTypeConfiguration<InvoiceDetail>
    {
        public void Configure(EntityTypeBuilder<InvoiceDetail> builder)
        {
            builder.Property(x => x.InvoiceNo).IsRequired();
            builder.HasOne(u => u.Invoice).WithMany(r => r.InvoiceDetails).HasForeignKey(u => u.InvoiceNo);
            builder.Property(t => t.Price).IsRequired();
            builder.Property(t => t.Discount).IsRequired();
            builder.HasKey(c => new { c.InvoiceNo, c.TourId });
            builder.HasOne(u => u.Tour).WithOne(r => r.InvoiceDetail);
        }
    }
}