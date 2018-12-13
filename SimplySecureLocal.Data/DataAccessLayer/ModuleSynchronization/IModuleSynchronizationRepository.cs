using SimplySecureLocal.Data.DataAccessLayer.Module;
using System.Threading.Tasks;

namespace SimplySecureLocal.Data.DataAccessLayer.ModuleSynchronization
{
    public interface IModuleSynchronizationRepository
    {
        Task SynchronizeModules(IModuleRepository moduleRepository);
    }
}