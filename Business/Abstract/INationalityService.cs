using Entities.Concrete;

namespace Business.Abstract
{
    public interface INationalityService
    {
        List<Nationality> GetAll();

        Nationality GetById(int id);

        public void Add(Nationality nationality);

        public void Update(Nationality nationality);

        public void Delete(Nationality nationality);
    }
}
