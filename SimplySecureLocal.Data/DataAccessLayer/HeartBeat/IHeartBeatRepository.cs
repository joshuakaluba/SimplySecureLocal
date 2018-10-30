using SimplySecureLocal.Data.Models;
using System.Threading.Tasks;

namespace SimplySecureLocal.Data.DataAccessLayer.HeartBeat
{
    public interface IHeartBeatRepository
    {
        Task CreateHeartBeat(Models.HeartBeat bootMessage);
    }
}