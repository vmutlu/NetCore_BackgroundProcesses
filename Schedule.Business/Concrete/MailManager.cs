using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Schedule.Business.Abstract;
using Schedule.Entities.Dtos.Mail;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Schedule.Business.Concrete
{
    public class MailManager : IMailService
    {
        private readonly SmtpConfigDto _smtpConfigDto;
        private readonly IUserService _userService;

        public MailManager(IOptions<SmtpConfigDto> options, IUserService userService)
        {
            _smtpConfigDto = options.Value;
            _userService = userService;
        }

        public async Task SendUserRegisterMailAsync(int userId)
        {
            using var client = CreateSmtpClient();
           var userInfo = await _userService.GetByUserId(userId);

            MailMessageDto mailMessageDto = new MailMessageDto
            {
                Body = "Kayıt işleminizi tamamlamak için  " + $"<a href='http://localhost:5001/api/Account?returnUrl=*"
                     + userInfo.UserGuid.ToString() + "'>linke</a> tıklayınız.",
                To = userInfo.Email,
                Subject = "Kullanıcı Kayıt Islemi Kontrol",
                From = _smtpConfigDto.User
            };

            MailMessage mailMessage = mailMessageDto.GetMailMessage();
            mailMessage.IsBodyHtml = true;
            await client.SendMailAsync(mailMessage);
        }

        private SmtpClient CreateSmtpClient()
        {
            SmtpClient smtp = new SmtpClient(_smtpConfigDto.Host, _smtpConfigDto.Port);
            smtp.Credentials = new NetworkCredential(_smtpConfigDto.User, _smtpConfigDto.Password);
            smtp.EnableSsl = _smtpConfigDto.UseSsl;
            return smtp;
        }

        public async Task SendMailAsync(MailMessageDto mailMessageDto)
        {
            MailMessage mailMessage = mailMessageDto.GetMailMessage();
            mailMessage.From = new MailAddress(_smtpConfigDto.User);

            using var client = CreateSmtpClient();
            await client.SendMailAsync(mailMessage);
        }
    }
}