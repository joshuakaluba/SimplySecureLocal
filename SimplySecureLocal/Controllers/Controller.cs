using Microsoft.AspNetCore.Mvc;
using SimplySecureLocal.Data.DataAccessLayer.BootMessages;
using SimplySecureLocal.Data.DataAccessLayer.HeartBeats;
using SimplySecureLocal.Data.DataAccessLayer.StatusChanges;

namespace SimplySecureLocal.Controllers
{
    public abstract class Controller : ControllerBase
    {
        protected IBootMessageRepository BootMessageRepository;

        protected IHeartBeatRepository HeartBeatRepository;

        protected IStatusChangesRepository StatusChangesRepository;
    }
}