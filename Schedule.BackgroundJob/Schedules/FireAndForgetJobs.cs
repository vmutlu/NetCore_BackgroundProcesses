using Schedule.BackgroundJob.Managers.FireAndForgetJobs;
using Schedule.Entities.Dtos.Mail;
using System;

namespace Schedule.BackgroundJob.Schedules
{
    /// <summary>
    /// <para><b>EN: </b> It is a background job type that works once and immediately.</para>
    /// <para><b>TR: </b> Bir kere ve hemen çalışan background job tipidir.</para>
    /// </summary>
    public static class FireAndForgetJobs
    {
        [Obsolete]
        public static void SendMailJob(MailMessageDto mailMessageDto)
        {
            Hangfire.BackgroundJob.Enqueue<EmailSendingScheduleJobManager>
                (
                 job => job.Process(mailMessageDto)
                 );
        }

    }
}