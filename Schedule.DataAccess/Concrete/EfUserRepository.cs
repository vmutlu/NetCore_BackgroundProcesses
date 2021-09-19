using Apsiyon.DataAcccess.EntityFramework;
using Schedule.DataAccess.Abstract;
using Schedule.DataAccess.Concrete.EntityFramework.Context;
using Schedule.Entities.Concrete;

namespace Schedule.DataAccess.Concrete
{
    public class EfUserRepository : EfRepositoryBase<User, ScheduleContext>, IUserRepository
    {
        public EfUserRepository(ScheduleContext scheduleContext) : base(scheduleContext)
        {

        }
    }
}
