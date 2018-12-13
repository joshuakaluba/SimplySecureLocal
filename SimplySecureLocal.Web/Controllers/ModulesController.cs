using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SimplySecureLocal.Data.DataAccessLayer.Module;
using SimplySecureLocal.Data.Models;
using System;
using System.Threading.Tasks;

namespace SimplySecureLocal.Web.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class ModulesController : Controller<ModulesController>
    {
        private readonly IModuleRepository _moduleRepository;

        public ModulesController(IModuleRepository moduleRepository, ILogger<ModulesController> logger)
            : base(logger)
        {
            _moduleRepository = moduleRepository;
        }

        public async Task<IActionResult> Get()
        {
            try
            {
                var modules
                    = await _moduleRepository.GetModules();

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