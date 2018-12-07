using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SimplySecureLocal.Data.DataAccessLayer.BootMessage;
using SimplySecureLocal.Data.DataAccessLayer.HeartBeat;
using SimplySecureLocal.Data.DataAccessLayer.StateChange;
using SimplySecureLocal.Data.Initialization;
using NSwag.AspNetCore;
using NJsonSchema;
using SimplySecureLocal.Data.DataAccessLayer.Module;

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

            services.AddScoped<IStateChangesRepository, StateChangesRepository>();

            services.AddScoped<IModuleRepository, ModuleRepository>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddSwagger();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseMvc();

            app.UseSwaggerUi(typeof(Startup).GetTypeInfo().Assembly, settings =>
            {
                settings.GeneratorSettings.DefaultUrlTemplate = "{controller}/{action}/{id?}";
            });

            DataContextInitializer.Seed(app.ApplicationServices).Wait();
        }
    }
}