using Microsoft.EntityFrameworkCore;
using SimplySecureLocal.Data.Models;
using SimplySecureLocal.Data.Models.Static;

namespace SimplySecureLocal.Data.DataContext
{
    internal sealed class SimplySecureDataContext : DbContext
    {
        internal DbSet<BootMessage> BootMessages { get; set; }

        internal DbSet<HeartBeat> HeartBeats { get; set; }

        internal DbSet<StateChange> StateChanges { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString
                = $"Server={ApplicationConfig.DatabaseHost};" +
                    $"database={ApplicationConfig.DatabaseName};" +
                        $"uid={ApplicationConfig.DatabaseUser};" +
                            $"pwd={ApplicationConfig.DatabasePassword};" +
                                $"pooling=true;";

            optionsBuilder.UseMySql(connectionString);
        }
    }
}