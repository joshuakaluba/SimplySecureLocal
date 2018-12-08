using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SimplySecureLocal.Data.DataAccessLayer.BootMessage;
using SimplySecureLocal.Data.Models;
using SimplySecureLocal.Data.ViewModels;
using System;
using System.Threading.Tasks;
using SimplySecureLocal.Data.DataAccessLayer.Module;

namespace SimplySecureLocal.Web.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class BootController : Controller<BootController>
    {
        public BootController(IModuleRepository moduleRepository, IBootMessageRepository bootMessageRepository, ILogger<BootController> logger)
            : base(logger)
        {
            BootMessageRepository = bootMessageRepository;

            ModuleRepository = moduleRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] BaseComponentViewModel bootViewModel)
        {
            try
            {
                var id = Guid.Parse(bootViewModel.ModuleId);

                var bootMessage = new BootMessage
                {
                    ModuleId = id,

                    State = bootViewModel.State
                };

                await BootMessageRepository.CreateBootMessage(bootMessage);

                await ModuleRepository.UpdateModuleHeartbeat
                    (new Module(id, bootViewModel.State));

                var moduleResponse
                    = await BootMessageRepository
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