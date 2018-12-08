using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SimplySecureLocal.Data.DataAccessLayer.HeartBeat;
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
    public class ModulesController : Controller<ModulesController>
    {
        public ModulesController(IModuleRepository moduleRepository, ILogger<ModulesController> logger)
            : base(logger)
        {
            ModuleRepository = moduleRepository;
        }

        public async Task<IActionResult> Get()
        {
            try
            {
                var modules
                    = await ModuleRepository.GetModules();

                return Ok(modules);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message);

                return BadRequest(new ErrorResponse(ex));
            }
        }
    }
}
