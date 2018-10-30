using Microsoft.AspNetCore.Mvc;
using SimplySecureLocal.Common.Exception;
using SimplySecureLocal.Data.DataAccessLayer.BootMessage;
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

                await BootMessageRepository.PostBootToBackendApi(bootMessage);

                var moduleResponse = new ModuleResponse
                {
                    Triggered = false,

                    Armed = false
                };

                return Ok(moduleResponse);
            }
            catch (ApiException ex)
            {
                return BadRequest(new ErrorResponse(ex));
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse(ex));
            }
        }
    }
}