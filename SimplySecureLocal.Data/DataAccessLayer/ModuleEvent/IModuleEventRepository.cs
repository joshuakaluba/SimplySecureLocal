using SimplySecureLocal.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimplySecureLocal.Data.DataAccessLayer.ModuleEvent
{
    public interface IModuleEventRepository
    {
        Task CreateModuleEvent(Models.ModuleEvent moduleEvent);

        Task<List<Models.ModuleEvent>> GetModuleEvents();

        Task<ModuleResponse> PostModuleEvent(Models.ModuleEvent moduleEvent);
    }
}