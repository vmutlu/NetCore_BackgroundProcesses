using System.Threading.Tasks;

namespace Schedule.Business.DatabaseOperation
{
    public interface IDatabaseOptionService
    {
        Task BackupDatabase();

        Task RestoreDatabase();
    }
}