using SimplySecureLocal.Common.Exception;
using SimplySecureLocal.Data.DataAccessLayer.Module;
using SimplySecureLocal.Data.Models.Static;
using System.Net.Http;
using System.Threading.Tasks;

namespace SimplySecureLocal.Data.DataAccessLayer.ModuleSynchronization
{
    public class ModuleSynchronizationRepository : BaseRepository, IModuleSynchronizationRepository
    {
        public async Task SynchronizeModules(IModuleRepository moduleRepository)
        {
            var modules = await moduleRepository.GetModules();

            if (modules != null && modules.Count > 0)
            {
                using (var client = ApplicationHttpClient(ApplicationConfig.BackendUri))
                {
                    var response
                        = await client.PostAsJsonAsync
                            (BackendServerEndPoint.SynchronizeModules, modules);

                    if (response.IsSuccessStatusCode == false)
                    {
                        var ex = ApiException.CreateApiException(response);

                        throw ex;
                    }
                }
            }
        }
    }
}