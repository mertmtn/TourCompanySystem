using Entities.Abstract;

namespace Entities.DTO
{
    public class UserForRegisterDto : IDTO
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MaidenName { get; set; }
    }
}
