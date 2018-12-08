using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SimplySecureLocal.Data.DataAccessLayer.StateChange;
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
    public class StateChangeController : Controller<StateChangeController>
    {
        public StateChangeController(IModuleRepository moduleRepository,  IStateChangesRepository stateChangesRepository, ILogger<StateChangeController> logger)
            : base(logger)
        {
            StateChangesRepository = stateChangesRepository;

            ModuleRepository = moduleRepository;
        }

        public async Task<IActionResult> Get()
        {
            try
            {
                var stateChanges
                    = await StateChangesRepository.GetStateChanges();

                return Ok(stateChanges);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message);

                return BadRequest(new ErrorResponse(ex));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] BaseComponentViewModel stateChangeViewModel)
        {
            try
            {
                var id = Guid.Parse(stateChangeViewModel.ModuleId);

                var stateChange = new StateChange
                {
                    ModuleId = id,

                    State = stateChangeViewModel.State
                };

                await StateChangesRepository.CreateStateChange(stateChange);

                await ModuleRepository.UpdateModuleHeartbeat(new Module(id, stateChangeViewModel.State));

                var moduleResponse
                    = await StateChangesRepository
                        .PostStateChangeToBackendApi(stateChange);

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