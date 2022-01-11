using Core.Entities;

namespace Entities.Concrete
{
    public class Language :IEntity
    {
        public Language()
        {
            Guides = new HashSet<Guide>();
        }    

        public int LanguageId { get; set; }

        public string Name { get; set; }
        public ICollection<Guide> Guides { get; set; }
    }
}
