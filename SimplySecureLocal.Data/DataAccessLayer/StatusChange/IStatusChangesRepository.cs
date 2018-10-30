using System.Collections.Generic;
using SimplySecureLocal.Data.Models;
using System.Threading.Tasks;

namespace SimplySecureLocal.Data.DataAccessLayer.StatusChange
{
    public interface IStatusChangesRepository
    {
        Task CreateStatusChange(Models.StatusChange statusChange);

        Task<List<Models.StatusChange>> GetStatusChanges();
    }
}