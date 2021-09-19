using Schedule.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Schedule.Business.Abstract
{
    public interface IUserService
    {
        Task<User> GetByUserId(int userId);

        void Add(User user);

        void Update(User user);

        Task<User> GetByMail(string email);

        Task<User> UserGetByUniqNumber(Guid userUniqNumber);

        Task<List<User>> GetUnRegisterUsers();

        Task<User> Logining(string mail, string password);
    }
}