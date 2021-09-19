using Schedule.Business.Abstract;
using System;
using System.Threading.Tasks;

namespace Schedule.BackgroundJob.Managers.DelayedJobs
{
    public class UserRegisterScheduleJobManager
    {
        private readonly IMailService _mailService;

        public UserRegisterScheduleJobManager(IMailService mailService)
        {
            _mailService = mailService ?? throw new ArgumentNullException(nameof(mailService));
        }

        public async Task Process(int userId)
        {
            await _mailService.SendUserRegisterMailAsync(userId);
        }
    }
}