using Business.Abstract;
using Business.Constants.Messages;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Exception;
using Core.Aspects.Autofac.Validation;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Results.Error;
using Core.Utilities.Results.Success;
using Core.Utilities.Security.Hashing;
using Data.Abstract;
using Entities.DTO;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        private IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        [ValidationAspect(typeof(UserRegisterValidator), Priority = 1)]
        [ExceptionAspect(typeof(Result))]
        public IResult Register(UserForRegisterDto userForRegisterDto)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(userForRegisterDto.Password, out passwordHash, out passwordSalt);
            var user = new User
            {
                EMail = userForRegisterDto.Email,
                FirstName = userForRegisterDto.FirstName,

                LastName = userForRegisterDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                IsActive = true,
                CreatedDate = DateTime.Now
            };
            _userDal.Add(user);
            return new SuccessResult(UserMessage.UserRegistered);
        }

        public IDataResult<User> GetByMail(string email)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.EMail == email));
        }       

        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult("UserMessage.UserDeletedSuccessfully");
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll());
        }

        public IDataResult<User> GetById(int userId)
        {
            return new SuccessDataResult<User>(_userDal.Get(c => c.Id == userId));
        }

        [ValidationAspect(typeof(UserUpdateValidator), Priority = 1)]
        [ExceptionAspect(typeof(Result))]
        public IResult UpdateUserInfo(User user)
        {
            _userDal.UpdateUserInfo(user);
            return new SuccessResult("");
        }

        public IResult UserExists(string email)
        {
            if (GetByMail(email).Data != null)
            {
                return new ErrorResult(UserMessage.UserAlreadyExists);
            }
            return new SuccessResult();
        }      

        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            return new SuccessDataResult<List<OperationClaim>>(_userDal.GetClaims(user));
        }

        public IDataResult<List<OperationClaim>> GetClaimsByUserId(int userId)
        {
            return new SuccessDataResult<List<OperationClaim>>(_userDal.GetClaimsByUserId(userId));
        }
    }
}
