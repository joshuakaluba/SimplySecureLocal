using Microsoft.AspNetCore.Mvc;
using SimplySecureLocal.Data.DataAccessLayer.BootMessage;
using SimplySecureLocal.Data.DataAccessLayer.HeartBeat;
using SimplySecureLocal.Data.DataAccessLayer.StatusChange;

namespace SimplySecureLocal.Controllers
{
    public abstract class Controller : ControllerBase
    {
        protected IBootMessageRepository BootMessageRepository;

        protected IHeartBeatRepository HeartBeatRepository;

        protected IStatusChangesRepository StatusChangesRepository;
    }
}