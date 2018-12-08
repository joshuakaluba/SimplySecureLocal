using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SimplySecureLocal.Data.DataAccessLayer.BootMessage;
using SimplySecureLocal.Data.DataAccessLayer.Heartbeat;
using SimplySecureLocal.Data.DataAccessLayer.Module;
using SimplySecureLocal.Data.DataAccessLayer.StateChange;

namespace SimplySecureLocal.Controllers
{
    public abstract class Controller<T> : ControllerBase
    {
        protected ILogger<T> Logger;

        protected IBootMessageRepository BootMessageRepository;

        protected IHeartbeatRepository HeartbeatRepository;

        protected IStateChangesRepository StateChangesRepository;

        protected IModuleRepository ModuleRepository;

        protected Controller(ILogger<T> logger)
        {
            Logger = logger;
        }
    }
}