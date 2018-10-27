using System;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using SimplySecureLocal.Data.Static;

namespace SimplySecureLocal
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseUrls($"http://*:{ApplicationKeys.Port}")
                    .UseStartup<Startup>();
    }
}