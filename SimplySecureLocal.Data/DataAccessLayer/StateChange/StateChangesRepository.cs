using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SimplySecureLocal.Common.Exception;
using SimplySecureLocal.Data.DataContext;
using SimplySecureLocal.Data.Models;
using SimplySecureLocal.Data.Models.Static;

namespace SimplySecureLocal.Data.DataAccessLayer.StateChange
{
    public sealed class StateChangesRepository : BaseRepository, IStateChangesRepository
    {
        public async Task CreateStateChange(Models.StateChange stateChange)
        {
            using (DataContext = new SimplySecureDataContext())
            {
                DataContext.StateChanges.Add(stateChange);

                await DataContext.SaveChangesAsync();
            }
        }

        public async Task<List<Models.StateChange>> GetStateChanges()
        {
            using (DataContext = new SimplySecureDataContext())
            {
                var statusChanges = await DataContext.StateChanges.ToListAsync();

                return statusChanges;
            }
        }

        public async Task<ModuleResponse> PostStateChangeToBackendApi(Models.StateChange stateChange)
        {
            using (var client = ApplicationHttpClient(ApplicationConfig.BackendUri))
            {
                var response = await client.PostAsJsonAsync(ApplicationEndPoint.StatusChange, stateChange);

                if (response.IsSuccessStatusCode)
                {
                    var moduleResponse
                        = await response.Content.ReadAsAsync<ModuleResponse>();

                    return moduleResponse;
                }
                else
                {
                    throw ApiException.CreateApiException(response);
                }
            }
        }
    }
}