using Schedule.Entities.Concrete;
using Schedule.Entities.Dtos.Account;
using System.Threading.Tasks;

namespace Schedule.Business.Abstract
{
    public interface IAuthService
    {
        Task<User> Register(UserForRegisterDto userForRegisterDto);

        Task<User> Login(UserForLoginDto userForLoginDto);

        Task<bool> UserExists(string email);

        Task<bool> UserActivatedRegister(string userMailUrl);
    }
}