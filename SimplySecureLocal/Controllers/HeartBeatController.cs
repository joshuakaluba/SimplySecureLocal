using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SimplySecureLocal.Data.DataAccessLayer.HeartBeat;
using SimplySecureLocal.Data.Models;
using SimplySecureLocal.Data.ViewModels;
using System;
using System.Threading.Tasks;

namespace SimplySecureLocal.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class HeartBeatController : Controller<HeartBeatController>
    {
        public HeartBeatController(IHeartBeatRepository heartBeatRepository, Logger<HeartBeatController> logger)
        : base(logger)
        {
            HeartBeatRepository = heartBeatRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] BaseComponentViewModel heartBeatViewModel)
        {
            try
            {
                var heartBeat = new HeartBeat
                {
                    ModuleId = Guid.Parse(heartBeatViewModel.ModuleId),

                    State = heartBeatViewModel.Status
                };

                await HeartBeatRepository.CreateHeartBeat(heartBeat);

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