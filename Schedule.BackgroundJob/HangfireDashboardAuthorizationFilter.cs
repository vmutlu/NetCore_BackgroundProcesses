using Hangfire.Dashboard;
using Schedule.Entities.Enums;
using System.Diagnostics.CodeAnalysis;

namespace Schedule.BackgroundJob
{
    public class HangfireDashboardAuthorizationFilter : IDashboardAuthorizationFilter
    {
        public bool Authorize([NotNull] DashboardContext context)
        {
            var useRole = "HangfireOpenUser";
            return useRole == RoleEnums.HangfireOpenUser.ToString();
        }
    }
}
