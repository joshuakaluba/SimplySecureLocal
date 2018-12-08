using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SimplySecureLocal.Data.DataAccessLayer.Heartbeat;
using SimplySecureLocal.Data.Models;
using SimplySecureLocal.Data.ViewModels;
using System;
using System.Threading.Tasks;
using SimplySecureLocal.Data.DataAccessLayer.Module;

namespace SimplySecureLocal.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class HeartbeatController : Controller<HeartbeatController>
    {
        public HeartbeatController(IHeartbeatRepository heartbeatRepository, IModuleRepository moduleRepository, ILogger<HeartbeatController> logger)
        : base(logger)
        {
            HeartbeatRepository = heartbeatRepository;

            ModuleRepository = moduleRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] BaseComponentViewModel heartbeatViewModel)
        {
            try
            {
                var id = Guid.Parse(heartbeatViewModel.ModuleId);

                var heartbeat = new Heartbeat
                {
                    ModuleId = id,

                    State = heartbeatViewModel.State
                };

                await HeartbeatRepository.CreateHeartbeat(heartbeat);

                await ModuleRepository.UpdateModuleHeartbeat
                    (new Module(id, heartbeatViewModel.State));

                return Ok(heartbeat);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message);

                return BadRequest(new ErrorResponse(ex));
            }
        }
    }
}