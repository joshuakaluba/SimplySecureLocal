using System.Collections.Generic;
using SimplySecureLocal.Data.Models;
using System.Threading.Tasks;

namespace SimplySecureLocal.Data.DataAccessLayer.StatusChanges
{
    public interface IStatusChangesRepository
    {
        Task CreateStatusChange(StatusChange statusChange);

        Task<List<StatusChange>> GetStatusChanges();
    }
}