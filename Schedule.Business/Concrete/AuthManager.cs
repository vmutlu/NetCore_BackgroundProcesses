using Schedule.Business.Abstract;
using Schedule.Entities.Concrete;
using Schedule.Entities.Dtos.Account;
using System;
using System.Threading.Tasks;

namespace Schedule.Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private IUserService _userService;

        public AuthManager(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<User> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = await _userService.Logining(userForLoginDto.Email, userForLoginDto.Password);
            if (userToCheck == null)
                throw new Exception("Kullanıcı adı veya şifre yanlış. Lütfen tekrar deneyiniz.");

            return userToCheck;
        }

        public async Task<User> Register(UserForRegisterDto userForRegisterDto)
        {
            var userToCheck = await UserExists(userForRegisterDto.Email);
            if (userToCheck)
            {
                var user = new User
                {
                    Email = userForRegisterDto.Email,
                    FirstName = userForRegisterDto.FirstName,
                    LastName = userForRegisterDto.LastName,
                    Password = userForRegisterDto.Password,
                    Status = false,
                    UserGuid = Guid.NewGuid(),
                    IsActivatedMailSend = false
                };
                _userService.Add(user);
                return user;
            }
            throw new Exception("Bu mail adresi ile kullanıcı kayıtlı  !!!");
        }

        public async Task<bool> UserActivatedRegister(string userMailUrl)
        {
            Guid userUniqNumber = Guid.Parse(userMailUrl.Split("*")[1]);
            var userInfo = await _userService.UserGetByUniqNumber(userUniqNumber);
            if (userInfo != null)
            {
                userInfo.IsActivatedMailSend = true;
                userInfo.Status = true;
                _userService.Update(userInfo);
                return true;
            }

            else
                return false;
        }

        public async Task<bool> UserExists(string email)
        {
            if (await _userService.GetByMail(email) != null)
                return false;

            return true;
        }
    }
}