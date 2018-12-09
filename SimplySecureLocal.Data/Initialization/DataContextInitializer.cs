using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SimplySecureLocal.Data.DataContext;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SimplySecureLocal.Data.Initialization
{
    public static class DataContextInitializer
    {
        public static async Task Seed(IServiceProvider serviceProvider)
        {
            using (var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var dataContext = serviceScope.ServiceProvider.GetService<SimplySecureDataContext>();

                if (dataContext.Database.GetPendingMigrations().Any())
                {
                    await dataContext.Database.MigrateAsync();
                }
            }
        }
    }
}