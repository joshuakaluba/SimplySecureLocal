using Microsoft.AspNetCore.Mvc;
using SimplySecureLocal.Data.DataAccessLayer.BootMessage;
using SimplySecureLocal.Data.DataAccessLayer.HeartBeat;
using SimplySecureLocal.Data.DataAccessLayer.StatusChange;
using Microsoft.Extensions.Logging;

namespace SimplySecureLocal.Controllers
{
    public abstract class Controller<T> : ControllerBase
    {
        protected ILogger<T> Logger;

        protected IBootMessageRepository BootMessageRepository;

        protected IHeartBeatRepository HeartBeatRepository;

        protected IStatusChangesRepository StatusChangesRepository;

        protected Controller(ILogger<T> logger )
        {
            Logger = logger;
        }
    }
}