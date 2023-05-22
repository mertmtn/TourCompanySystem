using Core.Utilities.Results;
using Core.Utilities.Security.JsonWebToken;
using Core.Entities.Concrete; 
using Entities.DTO;

namespace Business.Abstract
{
    public interface IAuthService
    {      
        IDataResult<User> LoginUser(UserForLoginDto userForLoginDto);
      
        IDataResult<AccessToken> CreateAccessToken(User user);
    }
}
