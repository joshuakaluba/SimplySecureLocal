using SimplySecureLocal.Data.Models;
using System.Threading.Tasks;

namespace SimplySecureLocal.Data.DataAccessLayer.HeartBeats
{
    public interface IHeartBeatRepository
    {
        Task CreateHeartBeat(HeartBeat bootMessage);
    }
}