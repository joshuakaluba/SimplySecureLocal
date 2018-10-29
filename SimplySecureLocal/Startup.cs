using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SimplySecureLocal.Data.DataAccessLayer.BootMessages;
using SimplySecureLocal.Data.DataAccessLayer.HeartBeats;
using SimplySecureLocal.Data.DataAccessLayer.StatusChanges;
using SimplySecureLocal.Data.Initialization;

namespace SimplySecureLocal
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
            services.AddScoped<IBootMessageRepository, BootMessageRepository>();

            services.AddScoped<IHeartBeatRepository, HeartBeatRepository>();

            services.AddScoped<IStatusChangesRepository, StatusChangesRepository>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseMvc();

            DataContextInitializer.Seed(app.ApplicationServices).Wait();
        }
    }
}