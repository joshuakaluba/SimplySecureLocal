using Microsoft.EntityFrameworkCore;
using SimplySecureLocal.Data.Models;

namespace SimplySecureLocal.Data.DataContext
{
    internal sealed class SimplySecureDataContext : DbContext
    {
        internal DbSet<BootMessage> BootMessages { get; set; }

        internal DbSet<Heartbeat> Heartbeats { get; set; }

        internal DbSet<ModuleEvent> ModuleEvents { get; set; }

        internal DbSet<Module> Modules { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=SimplySecureLocalDb.db");
        }
    }
}