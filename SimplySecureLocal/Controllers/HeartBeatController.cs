using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SimplySecureLocal.Data.DataAccessLayer.HeartBeat;
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
    public class HeartBeatController : Controller<HeartBeatController>
    {
        public HeartBeatController(IHeartBeatRepository heartBeatRepository, IModuleRepository moduleRepository, ILogger<HeartBeatController> logger)
        : base(logger)
        {
            HeartBeatRepository = heartBeatRepository;
            ModuleRepository = moduleRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] BaseComponentViewModel heartBeatViewModel)
        {
            try
            {
                var id = Guid.Parse(heartBeatViewModel.ModuleId);

                var heartBeat = new HeartBeat
                {
                    ModuleId = id,

                    State = heartBeatViewModel.State
                };

                await HeartBeatRepository.CreateHeartBeat(heartBeat);

                await ModuleRepository.UpdateModuleHeartBeat
                    (new Module(id, heartBeatViewModel.State));

                return Ok(heartBeat);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message);

                return BadRequest(new ErrorResponse(ex));
            }
        }
    }
}