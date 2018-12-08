using System.Threading.Tasks;

namespace SimplySecureLocal.Data.DataAccessLayer.Heartbeat
{
    public interface IHeartbeatRepository
    {
        Task CreateHeartbeat(Models.Heartbeat heartbeat);
    }
}