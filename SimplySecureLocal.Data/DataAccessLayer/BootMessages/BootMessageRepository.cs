using System.Threading.Tasks;
using SimplySecureLocal.Data.DataContext;
using SimplySecureLocal.Data.Models;

namespace SimplySecureLocal.Data.DataAccessLayer.BootMessages
{
    public sealed class BootMessageRepository : BaseRepository, IBootMessageRepository
    {
        public async Task CreateBootMessage(BootMessage bootMessage)
        {
            using (DataContext = new SimplySecureDataContext())
            {
                DataContext.BootMessages.Add(bootMessage);

                await DataContext.SaveChangesAsync();
            }
        }
    }
}