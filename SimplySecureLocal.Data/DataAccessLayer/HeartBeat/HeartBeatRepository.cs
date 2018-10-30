using SimplySecureLocal.Data.DataContext;
using SimplySecureLocal.Data.Models;
using System.Threading.Tasks;

namespace SimplySecureLocal.Data.DataAccessLayer.HeartBeat
{
    public sealed class HeartBeatRepository : BaseRepository, IHeartBeatRepository
    {
        public async Task CreateHeartBeat(Models.HeartBeat heartBeat)
        {
            using (DataContext = new SimplySecureDataContext())
            {
                DataContext.HeartBeats.Add(heartBeat);

                await DataContext.SaveChangesAsync();
            }
        }
    }
}