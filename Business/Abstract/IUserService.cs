 
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.DTO;

namespace Business.Abstract
{
    public interface IUserService
    {
        IResult UserExists(string email);
        IDataResult<User> GetById(int userId);
        IDataResult<List<User>> GetAll();
        IResult Register(UserForRegisterDto userForRegisterDto);
        IResult UpdateUserInfo(User user);
        IDataResult<User> GetByMail(string email);

        IDataResult<List<OperationClaim>> GetClaims(User user);
        IDataResult<List<OperationClaim>> GetClaimsByUserId(int userId);

    }
}
