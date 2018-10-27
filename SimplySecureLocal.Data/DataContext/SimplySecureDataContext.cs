using Microsoft.EntityFrameworkCore;
using SimplySecureLocal.Data.Models;
using SimplySecureLocal.Data.Static;

namespace SimplySecureLocal.Data.DataContext
{
    internal sealed class SimplySecureDataContext : DbContext
    {
        internal DbSet<BootMessage> BootMessages { get; set; }

        internal DbSet<HeartBeat> HeartBeats { get; set; }

        internal DbSet<StatusChange> StatusChanges { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString
                = $"Server={ApplicationKeys.DatabaseHost};" +
                    $"database={ApplicationKeys.DatabaseName};" +
                        $"uid={ApplicationKeys.DatabaseUser};" +
                            $"pwd={ApplicationKeys.DatabasePassword};" +
                                $"pooling=true;";

            optionsBuilder.UseMySql(connectionString);
        }
    }
}