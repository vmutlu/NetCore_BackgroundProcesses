using Schedule.Entities.Dtos.Mail;
using System.Threading.Tasks;

namespace Schedule.Business.Abstract
{
    public interface IMailService
    {
        Task SendMailAsync(MailMessageDto mailMessageDto);

        Task SendUserRegisterMailAsync(int userId);
    }
}