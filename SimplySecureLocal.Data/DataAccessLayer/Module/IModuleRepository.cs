using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimplySecureLocal.Data.DataAccessLayer.Module
{
    public interface IModuleRepository
    {
        Task<List<Models.Module>> GetModules();

        Task UpdateModuleHeartbeat(Models.Module module);
    }
}