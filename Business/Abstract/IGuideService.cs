using Entities.Concrete;

namespace Business.Abstract
{
    public interface IGuideService
    {
        List<Guide> GetAll();

        Guide GetById(int id);
    }
}
