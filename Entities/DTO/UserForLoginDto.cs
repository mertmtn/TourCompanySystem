using Entities.Abstract;

namespace Entities.DTO
{
    public class UserForLoginDto : IDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
