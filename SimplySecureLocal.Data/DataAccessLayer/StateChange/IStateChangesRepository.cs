using System.Collections.Generic;
using System.Threading.Tasks;
using SimplySecureLocal.Data.Models;

namespace SimplySecureLocal.Data.DataAccessLayer.StateChange
{
    public interface IStateChangesRepository
    {
        Task CreateStateChange(Models.StateChange stateChange);

        Task<List<Models.StateChange>> GetStateChanges();

        Task<ModuleResponse> PostStateChangeToBackendApi(Models.StateChange stateChange);
    }
}