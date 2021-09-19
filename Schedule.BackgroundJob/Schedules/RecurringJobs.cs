using Hangfire;
using Schedule.BackgroundJob.Managers.RecurringJobs;
using System;

namespace Schedule.BackgroundJob.Schedules
{
    /// <summary>
    /// <para><b>EN: </b> Runs multiple times (repetitive jobs) and during the specified CRON</para>
    /// <para><b>TR: </b> Çok kez (tekrarlı işler) ve belirtilmiş CRON süresince çalışır</para>
    /// </summary>
    public static class RecurringJobs
    {
        [Obsolete]
        public static void DatabaseBackupOperation()
        {
            RecurringJob.RemoveIfExists(nameof(DataBaseBackupScheduleJobManager));
            RecurringJob.AddOrUpdate<DataBaseBackupScheduleJobManager>(nameof(DataBaseBackupScheduleJobManager),
                job => job.Process(),"59 23 * * *", TimeZoneInfo.Local);
        } 
    }
}


