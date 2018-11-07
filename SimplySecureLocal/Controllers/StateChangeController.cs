using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SimplySecureLocal.Data.DataAccessLayer.StateChange;
using SimplySecureLocal.Data.Models;
using SimplySecureLocal.Data.ViewModels;
using System;
using System.Threading.Tasks;

namespace SimplySecureLocal.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class StateChangeController : Controller<StateChangeController>
    {
        public StateChangeController(IStateChangesRepository stateChangesRepository, ILogger<StateChangeController> logger)
            : base(logger)
        {
            StateChangesRepository = stateChangesRepository;
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
                var stateChange = new StateChange
                {
                    ModuleId = Guid.Parse(stateChangeViewModel.ModuleId),

                    State = stateChangeViewModel.Status
                };

                await StateChangesRepository.CreateStateChange(stateChange);

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