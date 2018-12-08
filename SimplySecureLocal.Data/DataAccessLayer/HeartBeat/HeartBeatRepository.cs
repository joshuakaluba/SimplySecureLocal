using SimplySecureLocal.Data.DataContext;
using System.Threading.Tasks;

namespace SimplySecureLocal.Data.DataAccessLayer.Heartbeat
{
    public sealed class HeartbeatRepository : BaseRepository, IHeartbeatRepository
    {
        public async Task CreateHeartbeat(Models.Heartbeat heartbeat)
        {
            using (DataContext = new SimplySecureDataContext())
            {
                DataContext.Heartbeats.Add(heartbeat);

                await DataContext.SaveChangesAsync();
            }
        }
    }
}