﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NSwag.AspNetCore;
using SimplySecureLocal.Data.DataAccessLayer.BootMessage;
using SimplySecureLocal.Data.DataAccessLayer.Heartbeat;
using SimplySecureLocal.Data.DataAccessLayer.Module;
using SimplySecureLocal.Data.DataAccessLayer.ModuleEvent;
using SimplySecureLocal.Data.DataAccessLayer.ModuleSynchronization;
using SimplySecureLocal.Data.Initialization;
using System.Reflection;

namespace SimplySecureLocal.Web
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

            services.AddScoped<IHeartbeatRepository, HeartbeatRepository>();

            services.AddScoped<IModuleEventRepository, ModuleEventRepository>();

            services.AddScoped<IModuleRepository, ModuleRepository>();

            services.AddScoped<IModuleSynchronizationRepository, ModuleSynchronizationRepository>();

            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

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

            DataContextInitializer.Seed().Wait();
        }
    }
}