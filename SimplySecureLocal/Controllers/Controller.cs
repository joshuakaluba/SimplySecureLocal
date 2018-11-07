using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SimplySecureLocal.Data.DataAccessLayer.BootMessage;
using SimplySecureLocal.Data.DataAccessLayer.HeartBeat;
using SimplySecureLocal.Data.DataAccessLayer.StateChange;

namespace SimplySecureLocal.Controllers
{
    public abstract class Controller<T> : ControllerBase
    {
        protected ILogger<T> Logger;

        protected IBootMessageRepository BootMessageRepository;

        protected IHeartBeatRepository HeartBeatRepository;

        protected IStateChangesRepository StateChangesRepository;

        protected Controller(ILogger<T> logger)
        {
            Logger = logger;
        }
    }
}