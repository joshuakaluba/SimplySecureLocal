using Microsoft.AspNetCore.Mvc;
using SimplySecureLocal.Data.DataAccessLayer.HeartBeats;
using SimplySecureLocal.Data.Models;
using SimplySecureLocal.Data.ViewModels;
using System;
using System.Threading.Tasks;

namespace SimplySecureLocal.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class HeartBeatController : Controller
    {
        public HeartBeatController(IHeartBeatRepository heartBeatRepository)
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
                return BadRequest(new ErrorResponse(ex));
            }
        }
    }
}