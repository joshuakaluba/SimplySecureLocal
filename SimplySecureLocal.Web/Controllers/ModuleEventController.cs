using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SimplySecureLocal.Data.DataAccessLayer.Module;
using SimplySecureLocal.Data.DataAccessLayer.ModuleEvent;
using SimplySecureLocal.Data.Models;
using SimplySecureLocal.Data.ViewModels;
using System;
using System.Threading.Tasks;

namespace SimplySecureLocal.Web.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class ModuleEventController : Controller<ModuleEventController>
    {
        private readonly IModuleEventRepository _moduleEventRepository;
        private readonly IModuleRepository _moduleRepository;

        public ModuleEventController(IModuleRepository moduleRepository, IModuleEventRepository moduleEventRepository, ILogger<ModuleEventController> logger)
            : base(logger)
        {
            _moduleEventRepository = moduleEventRepository;

            _moduleRepository = moduleRepository;
        }

        public async Task<IActionResult> Get()
        {
            try
            {
                var moduleEvents
                    = await _moduleEventRepository.GetModuleEvents();

                return Ok(moduleEvents);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message);

                return BadRequest(new ErrorResponse(ex));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] BaseComponentViewModel moduleEventViewModel)
        {
            try
            {
                var id = Guid.Parse(moduleEventViewModel.ModuleId);

                var moduleEvent = new ModuleEvent
                {
                    ModuleId = id,

                    State = moduleEventViewModel.State
                };

                await _moduleEventRepository.CreateModuleEvent(moduleEvent);

                await _moduleRepository.UpdateModuleHeartbeat(new Module(id, moduleEventViewModel.State));

                var moduleResponse
                    = await _moduleEventRepository
                        .PostModuleEvent(moduleEvent);

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