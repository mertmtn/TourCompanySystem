using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfGuideDal : EfEntityRepositoryBase<Guide, TourCompanyDbContext>, IGuideDal
    {
        public void AddManyLanguages(Guide guide, string[] selectedLanguages)
        {
            using (var context = new TourCompanyDbContext())
            {
                if (selectedLanguages != null)
                {
                    selectedLanguages.ToList()
                        .ForEach(lang => guide.Languages.Add(context.Languages.Find(Convert.ToInt32(lang))));
                }
                context.Add(guide);

                context.SaveChanges();
            }
        }
        public void UpdateManyLanguages(Guide guide, string[] selectedLanguages)
        {
            using (var context = new TourCompanyDbContext())
            {
                if (selectedLanguages != null)
                {
                    var item = context.Entry(guide);
                    //change item state to modified
                    item.State = EntityState.Modified;

                    //load existing items for ManyToMany collection
                    item.Collection(i => i.Languages).Load();

                    //clear Languages items          
                    guide.Languages.Clear();

                    selectedLanguages.ToList()
                        .ForEach(lang => guide.Languages.Add(context.Languages.Find(Convert.ToInt32(lang))));
                }
                
                context.SaveChanges();
            }
        }
        public Guide GetById(int id)
        {
            using (var context = new TourCompanyDbContext())
            {
                // get specific cart including all items
                return context.Guides.Include(g=>g.Languages).ThenInclude(row => row.Guides).First(cart => cart.GuideId == id);
                //// get all items belonging to cart
                //var cartItems = guideIncludingLanguages.Languages.Select(row => row.Guides);

            }
        }

        public void DeleteManyLanguages(Guide guide)
        {
            using (var context = new TourCompanyDbContext())
            {
                var guideToRemove = context.Guides.First(row => row.GuideId == guide.GuideId);
                
                context.RemoveRange(guideToRemove.Languages);
                context.SaveChanges();

                context.Remove(guideToRemove);
                context.SaveChanges();
            }
        }
    }
}
