using Apsiyon.Entities.Abstract;
using System;

namespace Schedule.Entities.Concrete
{
    public class User : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool Status { get; set; }
        public bool IsActivatedMailSend { get; set; }
        public Guid UserGuid { get; set; }
    }
}
