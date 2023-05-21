 
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
        IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password);
        IResult UpdateUserInfo(User user);
        IResult Delete(User user);
        IDataResult<List<OperationClaim>> GetClaims(User user);
        IDataResult<User> GetByMail(string email);
    }
}
