using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Utilities;
using Hangfire;
using Hangfire.SqlServer;
using Services;
namespace src
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        private void BuildAppSettings(IConfiguration configuration)
        {

            ApplicationConfig.DefaultConnectionString = configuration.GetConnectionString("DefaultConnection");
            ApplicationConfig.SecretKey = configuration["SecretKey"].ToString();
            ApplicationConfig.ZazzleRootUrl= configuration["ZazzleRootUrl"].ToString();
            ApplicationConfig.VendorId= configuration["VendorId"].ToString(); 
            ApplicationConfig.AppVersion = configuration["AppVersion"];
           
            ApplicationConfig.Environment = configuration["Environment"];
            ApplicationConfig.IsDeveloperMachine = configuration["IsDeveloperMachine"];
           
            ApplicationConfig.CurrentYear = configuration["CurrentYear"];
                 ApplicationConfig.SMTPConfig = new SMTPConfig
            {
                From = configuration.GetSection("Smtp:From").Value,
                Password = configuration.GetSection("Smtp:Pass").Value,
                Port = int.Parse(configuration.GetSection("Smtp:Port").Value),
                Server = configuration.GetSection("Smtp:Server").Value,
                User = configuration.GetSection("Smtp:User").Value
            };
        }
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddHangfireServer();
            services.AddHangfire(configuration => configuration
                .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                .UseSimpleAssemblyNameTypeSerializer()
                .UseRecommendedSerializerSettings()
                .UseSqlServerStorage(Configuration.GetConnectionString("Default"), new SqlServerStorageOptions
                {
                    CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
                    SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
                    QueuePollInterval = TimeSpan.Zero,
                    UseRecommendedIsolationLevel = true,
                    DisableGlobalLocks = true
                }));
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IBackgroundJobClient backgroundJobs, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseHangfireDashboard();
          backgroundJobs.Enqueue(() => Console.WriteLine("Hello world from Hangfire!"));
          //  RecurringJob.AddOrUpdate(() => new ZazzleDataService().ListNewOrders(), Cron.MinuteInterval(10));
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHangfireDashboard();
            });
            app.UseEndpoints(endpoints =>
            {

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });
        }
    }
}
