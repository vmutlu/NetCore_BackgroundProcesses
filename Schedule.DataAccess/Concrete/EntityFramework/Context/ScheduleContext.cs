using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Schedule.Entities.Concrete;
using System.IO;

namespace Schedule.DataAccess.Concrete.EntityFramework.Context
{
    public class ScheduleContext : DbContext
    {
        public ScheduleContext()
        {
        }

        public ScheduleContext(DbContextOptions<ScheduleContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var Configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            optionsBuilder.UseSqlServer(Configuration.GetConnectionString("ProjectDev"));
        }

        public DbSet<User> User { get; set; }
    }
}
