using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfTouristDal : EfEntityRepositoryBase<Tourist, TourCompanyDbContext>, ITouristDal
    {
        public List<Tourist> GetAllTouristDetail()
        {
            using (var context = new TourCompanyDbContext())
            {
                return context.Tourists.Include(t => t.Country).Include(t => t.Nationality).ToList();
            }
        }

        public Tourist GetAllTouristDetailById(int touristId)
        {
            using (var context = new TourCompanyDbContext())
            {
                return context.Tourists.Include(t => t.Country).Include(t => t.Nationality).FirstOrDefault(m => m.TouristId == touristId);
            }
        }

        public void UpdateForAddTours(int touristId, string[] selectedtours)
        {
            using (var context = new TourCompanyDbContext())
            {
                using (IDbContextTransaction transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        if (selectedtours != null)
                        {
                            var touristById = context.Tourists.Find(touristId);

                            var item = context.Entry(touristById);

                            //change item state to modified
                            item.State = EntityState.Modified;

                            //load existing items for ManyToMany collection
                            item.Collection(i => i.Tours).Load();

                            //clear Places items          
                            touristById.Tours.Clear();

                            selectedtours.ToList()
                                .ForEach(place => touristById.Tours.Add(context.Tours.Find(Convert.ToInt32(place))));

                            if (context.SaveChanges() > 0)
                            {
                                var invoiceDate = DateTime.Now;
                                var invoiceNo = "FTR" + invoiceDate.ToString("yyyyMMddHHmmss") + touristId.ToString();


                                context.Invoices.Add(new Invoice
                                {
                                    TouristId = touristId,
                                    InvoiceDate = invoiceDate,
                                    InvoiceNo = invoiceNo
                                });

                                var tourist = context.Tourists.Include(x => x.Tours).First(x => x.TouristId == touristId);
                                var tourList = tourist.Tours;
                                var isTouristAgeGreaterThan60 = (DateTime.Now.Year - tourist.BirthDate.Year) > 60;

                                foreach (var tour in tourList)
                                {
                                    var tourById = context.Tours.Include(x => x.Places).Where(x => x.TourId == tour.TourId);
                                    foreach (var tourPrice in tourById)
                                    {
                                        context.InvoiceDetails.Add(new InvoiceDetail { InvoiceNo = invoiceNo, TourId = tour.TourId, Discount = isTouristAgeGreaterThan60 ? 0.15 : 0, Price = tourPrice.Places.Sum(x => x.Price) });
                                    }
                                }
                                context.SaveChanges();
                            }

                            transaction.Commit();
                        }
                    }
                    catch
                    {
                        transaction.Rollback();
                    }
                }
            }
        }
    }
}
