using Microsoft.EntityFrameworkCore;
using SimplySecureLocal.Common.Exception;
using SimplySecureLocal.Data.DataContext;
using SimplySecureLocal.Data.Models;
using SimplySecureLocal.Data.Models.Static;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace SimplySecureLocal.Data.DataAccessLayer.ModuleEvent
{
    public sealed class ModuleEventRepository : BaseRepository, IModuleEventRepository
    {
        public async Task CreateModuleEvent(Models.ModuleEvent moduleEvent)
        {
            using (DataContext = new SimplySecureDataContext())
            {
                DataContext.ModuleEvents.Add(moduleEvent);

                await DataContext.SaveChangesAsync();
            }
        }

        public async Task<List<Models.ModuleEvent>> GetModuleEvents()
        {
            using (DataContext = new SimplySecureDataContext())
            {
                var statusChanges = await DataContext.ModuleEvents.ToListAsync();

                return statusChanges;
            }
        }

        public async Task<ModuleResponse> PostModuleEvent(Models.ModuleEvent moduleEvent)
        {
            using (var client = ApplicationHttpClient(ApplicationConfig.BackendUri))
            {
                var response = await client.PostAsJsonAsync(BackendServerEndPoint.ModuleEvent, moduleEvent);

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