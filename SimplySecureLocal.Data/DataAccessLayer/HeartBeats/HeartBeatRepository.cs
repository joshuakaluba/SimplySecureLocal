using SimplySecureLocal.Data.DataContext;
using SimplySecureLocal.Data.Models;
using System.Threading.Tasks;

namespace SimplySecureLocal.Data.DataAccessLayer.HeartBeats
{
    public sealed class HeartBeatRepository : BaseRepository, IHeartBeatRepository
    {
        public async Task CreateHeartBeat(HeartBeat heartBeat)
        {
            using (DataContext = new SimplySecureDataContext())
            {
                DataContext.HeartBeats.Add(heartBeat);

                await DataContext.SaveChangesAsync();
            }
        }
    }
}