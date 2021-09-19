using Schedule.Business.Abstract;
using Schedule.DataAccess.Abstract;
using Schedule.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Schedule.Business.Concrete
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void Add(User user)
        {
            _userRepository.Add(user);
        }

        public async Task<User> GetByMail(string email)
        {
            return await _userRepository.GetAsync(u => u.Email == email).ConfigureAwait(false);
        }

        public async Task<User> UserGetByUniqNumber(Guid userUniqNumber)
        {
            return await _userRepository.GetAsync(u => u.UserGuid == userUniqNumber).ConfigureAwait(false);
        }

        public async Task<List<User>> GetUnRegisterUsers()
        {
            return await _userRepository.GetAllAsync(u => u.IsActivatedMailSend == false && u.Status == false).ConfigureAwait(false);
        }

        public void Update(User user)
        {
            _userRepository.Update(user);
        }

        public async Task<User> GetByUserId(int userId)
        {
            return await _userRepository.GetAsync(u => u.Id == userId).ConfigureAwait(false);
        }

        public async Task<User> Logining(string mail, string password)
        {
            return await _userRepository.GetAsync(u => u.Email == mail && u.Password == password).ConfigureAwait(false);
        }
    }
}