using Schedule.BackgroundJob.Managers.DelayedJobs;
using System;

namespace Schedule.BackgroundJob.Schedules
{
    /// <summary>
    /// <para><b>EN: </b> It is a job type that only runs once a certain (set) time after it is created.</para>
    /// <para><b>TR: </b> Oluşturulduktan belirli bir (ayarlanan) zaman sonra sadece tek seferliğine çalışan job türüdür.</para>
    /// </summary>
    public static class DelayedJobs
    {
        [Obsolete]
        public static void SendMailRegisterJobs(int userId)
        {
            Hangfire.BackgroundJob.Schedule<UserRegisterScheduleJobManager>
                 (
                  job => job.Process(userId),
                  TimeSpan.FromSeconds(10)
                  );
        } 
    }
}





