using Apsiyon.Entities.Abstract;

namespace Schedule.Entities.Dtos.Account
{
    public class UserForLoginDto : IDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}