using Core.Entities;

namespace Entities.Concrete
{
    public class Nationality : IEntity
    {
        public Nationality()
        {
            Tourists = new HashSet<Tourist>();
        }


        public int NationalityId { get; set; }

        public string Name { get; set; }

        public bool IsActive { get; set; }

        public ICollection<Tourist> Tourists { get; set; }
    }
}
