using Core.Entities;

namespace Entities.Concrete
{
    public class Guide:IEntity
    {
        public Guide()
        {
            Languages = new HashSet<Language>();
        }

        public int GuideId { get; set; }  
        public string Name { get; set;}
        
        public string Surname { get; set; }

        public char Gender { get; set; } 

        public string PhoneNumber { get; set; }

        public bool IsActive { get; set; }

        public ICollection<Language> Languages { get; set; }

        public Tour Tour { get; set; }
    }
}
