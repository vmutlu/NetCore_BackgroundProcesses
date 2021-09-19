using Schedule.Business.DatabaseOperation;
using System.Threading.Tasks;

namespace Schedule.BackgroundJob.Managers.RecurringJobs
{
    public class DataBaseBackupScheduleJobManager
    {
        private readonly IDatabaseOptionService _databaseOptionService;

        public DataBaseBackupScheduleJobManager(IDatabaseOptionService databaseOptionService)
        {
            _databaseOptionService = databaseOptionService;
        }
  
        public async Task Process()
        {
            await _databaseOptionService.BackupDatabase();
        }
    }
}