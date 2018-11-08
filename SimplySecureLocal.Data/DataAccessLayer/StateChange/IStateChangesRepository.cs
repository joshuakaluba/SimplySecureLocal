using SimplySecureLocal.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimplySecureLocal.Data.DataAccessLayer.StateChange
{
    public interface IStateChangesRepository
    {
        Task CreateStateChange(Models.StateChange stateChange);

        Task<List<Models.StateChange>> GetStateChanges();

        Task<ModuleResponse> PostStateChangeToBackendApi(Models.StateChange stateChange);
    }
}