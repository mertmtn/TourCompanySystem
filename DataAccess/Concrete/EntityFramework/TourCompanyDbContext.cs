using DataAccess.Concrete.EntityFramework.Mappings;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class TourCompanyDbContext : DbContext
    {
       
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=TourCompanyDB;Trusted_Connection=True;");
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new GuideMapping());
            modelBuilder.ApplyConfiguration(new PlaceMapping());
            modelBuilder.ApplyConfiguration(new LanguageMapping());
            modelBuilder.ApplyConfiguration(new TouristMapping());
            modelBuilder.ApplyConfiguration(new CountryMapping());
            modelBuilder.ApplyConfiguration(new NationalityMapping());
            
            //TODO: Will be applied
            //modelBuilder.ApplyConfiguration(new TourMapping());
            //modelBuilder.ApplyConfiguration(new InvoiceMapping());
            //modelBuilder.ApplyConfiguration(new TourDetailMapping());
            //modelBuilder.ApplyConfiguration(new InvoiceDetailMapping());
        }

        public DbSet<Guide> Guides { get; set; }

        public DbSet<Language> Languages { get; set; }

        public DbSet<Tourist> Tourists { get; set; }

        public DbSet<Place> Places { get; set; }

        //public DbSet<Tour> Tours { get; set; }

        //public DbSet<TourDetail> TourDetails { get; set; }

        //public DbSet<InvoiceDetail> InvoiceDetails { get; set; }

        //public DbSet<Invoice> Invoices { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<Nationality> Nationalities { get; set; }

    }
}
