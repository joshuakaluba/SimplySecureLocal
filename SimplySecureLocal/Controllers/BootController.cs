using Microsoft.AspNetCore.Mvc;
using SimplySecureLocal.Data.DataAccessLayer.BootMessages;
using SimplySecureLocal.Data.Models;
using SimplySecureLocal.Data.ViewModels;
using System;
using System.Threading.Tasks;

namespace SimplySecureLocal.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class BootController : Controller
    {
        public BootController(IBootMessageRepository bootMessageRepository)
        {
            BootMessageRepository = bootMessageRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] BaseComponentViewModel bootViewModel)
        {
            try
            {
                var bootMessage = new BootMessage
                {
                    ModuleId = Guid.Parse(bootViewModel.ModuleId),

                    State = bootViewModel.Status
                };

                await BootMessageRepository.CreateBootMessage(bootMessage);

                var moduleResponse =  new ModuleResponse
                {
                    Triggered = false,
                    Armed = false
                };

                return Ok(moduleResponse);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse(ex));
            }
        }
    }
}