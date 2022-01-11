using Core.Entities;

namespace Entities.Concrete
{
    public class Nationality : IEntity
    {
        public int NationalityId { get; set; }

        public string Name { get; set; }
    }
}
