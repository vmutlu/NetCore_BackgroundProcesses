using Hangfire;
using Hangfire.SqlServer;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Schedule.Business.Abstract;
using Schedule.Business.Concrete;
using Schedule.Business.DatabaseOperation;
using Schedule.DataAccess.Abstract;
using Schedule.DataAccess.Concrete;
using Schedule.DataAccess.Concrete.EntityFramework.Context;
using Schedule.Entities.Dtos.Database;
using Schedule.Entities.Dtos.Mail;
using System;

namespace Schedule.API.Extensions
{
    public static class StartupExtesions
    {
        public static void ConfigureDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ScheduleContext>(option => option.UseSqlServer(configuration.GetConnectionString("ProjectDev").ToString(), o => { o.MigrationsAssembly("Schedule.DataAccess"); }));
            services.AddDbContext<ScheduleContext>(c => c.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));
        }

        public static IServiceCollection DependencyResolves(this IServiceCollection services, IConfiguration configuration)
        {
            // dependency
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, EfUserRepository>();

            services.AddScoped<IAuthService, AuthManager>();
            services.AddScoped<IMailService, MailManager>();

            services.AddScoped<IDatabaseOptionService, DatabaseOptionManager>();

            // configuration configure options
            services.Configure<SmtpConfigDto>(configuration.GetSection("SmtpConfig"));
            services.Configure<DatabaseOptionDto>(configuration.GetSection("DatabaseOption"));

            return services;
        }

        public static IServiceCollection AddHangfire(this IServiceCollection services, IConfiguration configuration)
        {
            var hangfire = configuration.GetConnectionString("HangfireDev");
            services.AddHangfire(configuration => configuration
                  .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                  .UseSimpleAssemblyNameTypeSerializer()
                  .UseRecommendedSerializerSettings()
                  .UseSqlServerStorage(hangfire, new SqlServerStorageOptions
                  {
                      CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
                      SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
                      QueuePollInterval = TimeSpan.Zero,
                      UseRecommendedIsolationLevel = true,
                      DisableGlobalLocks = true
                  }));

            return services;
        }
    }
}
