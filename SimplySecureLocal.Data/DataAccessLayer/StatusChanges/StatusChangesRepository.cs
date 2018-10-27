using SimplySecureLocal.Data.DataContext;
using SimplySecureLocal.Data.Models;
using System.Threading.Tasks;

namespace SimplySecureLocal.Data.DataAccessLayer.StatusChanges
{
    public sealed class StatusChangesRepository : BaseRepository, IStatusChangesRepository
    {
        public async Task CreateStatusChange(StatusChange statusChange)
        {
            using (DataContext = new SimplySecureDataContext())
            {
                DataContext.StatusChanges.Add(statusChange);

                await DataContext.SaveChangesAsync();
            }
        }
    }
}