using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess
{
    public class TourDetailMapping : IEntityTypeConfiguration<TourDetail>
    {
        public void Configure(EntityTypeBuilder<TourDetail> builder)
        {
            throw new NotImplementedException();
        }
    }
}