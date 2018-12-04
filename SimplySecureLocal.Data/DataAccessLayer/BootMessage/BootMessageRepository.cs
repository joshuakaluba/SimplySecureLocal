using SimplySecureLocal.Common.Exception;
using SimplySecureLocal.Data.DataContext;
using SimplySecureLocal.Data.Models;
using SimplySecureLocal.Data.Models.Static;
using System.Net.Http;
using System.Threading.Tasks;

namespace SimplySecureLocal.Data.DataAccessLayer.BootMessage
{
    public sealed class BootMessageRepository : BaseRepository, IBootMessageRepository
    {
        public async Task CreateBootMessage(Models.BootMessage bootMessage)
        {
            using (DataContext = new SimplySecureDataContext())
            {
                DataContext.BootMessages.Add(bootMessage);

                await DataContext.SaveChangesAsync();
            }
        }

        public async Task<ModuleResponse> PostBootToBackendApi(Models.BootMessage bootMessage)
        {
            using (var client = ApplicationHttpClient(ApplicationConfig.BackendUri))
            {
                var response = await client.PostAsJsonAsync(BackendServerEndPoint.ModuleBoot, bootMessage);

                if (response.IsSuccessStatusCode)
                {
                    var moduleResponse
                        = await response.Content.ReadAsAsync<ModuleResponse>();

                    return moduleResponse;
                }

                var ex = ApiException.CreateApiException(response);

                throw ex;
            }
        }
    }
}