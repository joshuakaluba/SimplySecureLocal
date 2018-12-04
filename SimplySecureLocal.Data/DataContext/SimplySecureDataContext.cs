using Microsoft.EntityFrameworkCore;
using SimplySecureLocal.Data.Models;

namespace SimplySecureLocal.Data.DataContext
{
    internal sealed class SimplySecureDataContext : DbContext
    {
        internal DbSet<BootMessage> BootMessages { get; set; }

        internal DbSet<HeartBeat> HeartBeats { get; set; }

        internal DbSet<StateChange> StateChanges { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=SimplySecureLocalDb.db");
        }
    }
}