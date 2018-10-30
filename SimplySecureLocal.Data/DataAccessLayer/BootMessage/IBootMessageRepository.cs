using SimplySecureLocal.Data.Models;
using System.Threading.Tasks;

namespace SimplySecureLocal.Data.DataAccessLayer.BootMessage
{
    public interface IBootMessageRepository
    {
        Task CreateBootMessage(Models.BootMessage bootMessage);

        Task<ModuleResponse> PostBootToBackendApi(Models.BootMessage bootMessage);
    }
}