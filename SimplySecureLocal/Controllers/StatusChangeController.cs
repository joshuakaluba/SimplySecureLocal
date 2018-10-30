using Microsoft.AspNetCore.Mvc;
using SimplySecureLocal.Data.DataAccessLayer.StatusChange;
using SimplySecureLocal.Data.Models;
using SimplySecureLocal.Data.ViewModels;
using System;
using System.Threading.Tasks;

namespace SimplySecureLocal.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class StatusChangeController : Controller
    {
        public StatusChangeController(IStatusChangesRepository statusChangesRepository)
        {
            StatusChangesRepository = statusChangesRepository;
        }

        public async Task<IActionResult> Get()
        {
            try
            {
                var statusChanges = await StatusChangesRepository.GetStatusChanges();

                return Ok(statusChanges);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse(ex));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] BaseComponentViewModel statusChangeViewModel)
        {
            try
            {
                var random = new Random();

                var statusChange = new StatusChange
                {
                    ModuleId = Guid.Parse(statusChangeViewModel.ModuleId),

                    State = statusChangeViewModel.Status
                };

                //TODO post to main server

                var moduleResponse = new ModuleResponse
                {
                    Triggered = random.Next(100) < 50 ? true : false,
                    Armed = false
                };

                await StatusChangesRepository.CreateStatusChange(statusChange);

                return Ok(moduleResponse);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse(ex));
            }
        }
    }
}