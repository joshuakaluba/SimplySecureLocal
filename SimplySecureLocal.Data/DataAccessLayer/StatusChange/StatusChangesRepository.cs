using System.Collections.Generic;
using SimplySecureLocal.Data.DataContext;
using SimplySecureLocal.Data.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SimplySecureLocal.Data.DataAccessLayer.StatusChange
{
    public sealed class StatusChangesRepository : BaseRepository, IStatusChangesRepository
    {
        public async Task CreateStatusChange(Models.StatusChange statusChange)
        {
            using (DataContext = new SimplySecureDataContext())
            {
                DataContext.StatusChanges.Add(statusChange);

                await DataContext.SaveChangesAsync();
            }
        }

        public async Task<List<Models.StatusChange>> GetStatusChanges()
        {
            using (DataContext = new SimplySecureDataContext())
            {
                var statusChanges = await DataContext.StatusChanges.ToListAsync();

                return statusChanges;
            }
        }
    }
}