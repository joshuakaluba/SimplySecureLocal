using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
    public class BootController : Controller<BootController>
    {
        public BootController(IBootMessageRepository bootMessageRepository, ILogger<BootController> logger)
            : base(logger)
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

                var moduleResponse 
                    =  await BootMessageRepository
                        .PostBootToBackendApi(bootMessage);
                
                return Ok(moduleResponse);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message);

                return BadRequest(new ErrorResponse(ex));
            }
        }
    }
}