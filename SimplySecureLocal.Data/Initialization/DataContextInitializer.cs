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
        public static async Task Seed()
        {
            using (var db = new SimplySecureDataContext())
            {
                if (db.Database.GetPendingMigrations().Any())
                {
                    await db.Database.MigrateAsync();
                }
            }
        }
    }
}