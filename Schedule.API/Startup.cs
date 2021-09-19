using Hangfire;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Schedule.API.Extensions;
using Schedule.BackgroundJob;
using Schedule.BackgroundJob.Schedules;
using System;

namespace Schedule.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.ConfigureDatabase(Configuration);

            services.AddHangfire(Configuration);

            services.DependencyResolves(Configuration);

            services.AddControllersWithViews();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Schedule.API", Version = "v1" });
            });
        }

        [Obsolete]
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Schedule.API v1"));
            }

            app.UseRouting();

            app.UseHangfireDashboard("/veyselmutlu", new DashboardOptions
            {
                DashboardTitle = "Veysel MUTLU Hangfire DashBoard",  // Dashboard sayfasýna ait Baþlýk alanýný deðiþtiririz.
                Authorization = new[] { new HangfireDashboardAuthorizationFilter() },   // Güvenlik için Authorization Ýþlemleri
            });

            app.UseHangfireServer();

           app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHangfireDashboard();
            });

            RecurringJobs.DatabaseBackupOperation();
        }
    }
}
