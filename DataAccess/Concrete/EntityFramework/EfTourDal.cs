using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfTourDal : EfEntityRepositoryBase<Tour, TourCompanyDbContext>, ITourDal
    {
        public void AddManyPlaces(Tour tour, string[] selectedPlaces)
        {
            using (var context = new TourCompanyDbContext())
            {
                if (selectedPlaces != null)
                {
                    selectedPlaces.ToList()
                        .ForEach(place => tour.Places.Add(context.Places.Find(Convert.ToInt32(place))));
                }
                context.Add(tour);

                context.SaveChanges();
            }
        }

        public void DeleteManyPlaces(Tour tour)
        {
            using (var context = new TourCompanyDbContext())
            {
                var tourToRemove = context.Tours.First(row => row.TourId == tour.TourId);

                context.RemoveRange(tourToRemove.Places);
                context.SaveChanges();

                context.Remove(tourToRemove);
                context.SaveChanges();
            }
        }

        public List<Tour> GetAllJoinedTours()
        {
            using (var context = new TourCompanyDbContext())
            {
                return context.Tours.Include(x => x.Guide).Include(g => g.Places).ToList();
            }
        }

        public Tour GetById(int id)
        {
            using (var context = new TourCompanyDbContext())
            {
                return context.Tours.Include(x => x.Guide).Include(g => g.Places).First(t => t.TourId == id);
            }
        }

        public void UpdateManyPlaces(Tour tour, string[] selectedPlaces)
        {
            using (var context = new TourCompanyDbContext())
            {
                if (selectedPlaces != null)
                {
                    var item = context.Entry(tour);

                    //change item state to modified
                    item.State = EntityState.Modified;

                    //load existing items for ManyToMany collection
                    item.Collection(i => i.Places).Load();

                    //clear Places items          
                    tour.Places.Clear();

                    selectedPlaces.ToList()
                        .ForEach(place => tour.Places.Add(context.Places.Find(Convert.ToInt32(place))));
                }

                context.SaveChanges();
            }
        }
    }
}
