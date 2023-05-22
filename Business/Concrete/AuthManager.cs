using Business.Abstract;
using Core.Utilities.Results.Error;
using Core.Utilities.Results.Success;
using Entities.DTO;
using Business.Constants.Messages;
using Core.Entities.Concrete; 
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JsonWebToken;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Exception;
using Core.Aspects.Autofac.Validation;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private IUserService _userService;
        private ITokenHelper _tokenHelper;

        public AuthManager(IUserService userService, ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }    
       
        [ValidationAspect(typeof(LoginValidator), Priority = 1)]
        [ExceptionAspect(typeof(DataResult<User>))]
        public IDataResult<User> LoginUser(UserForLoginDto userForLoginDto)
        {
            var userToCheck = _userService.GetByMail(userForLoginDto.Email).Data;
            if (userToCheck == null)
            {
                return new ErrorDataResult<User>(UserMessage.UserNotFound);
            }

            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
            {
                return new ErrorDataResult<User>(UserMessage.PasswordError);
            }

            return new SuccessDataResult<User>(userToCheck, UserMessage.SuccessfulLogin);
        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userService.GetClaims(user);
            var accessToken = _tokenHelper.CreateToken(user, claims.Data);
            return new SuccessDataResult<AccessToken>(accessToken, UserMessage.AccessTokenCreated);
        }
    }
}
