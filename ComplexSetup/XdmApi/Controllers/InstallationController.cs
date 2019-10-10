using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Xylem.BLL;

namespace Xylem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstallationController : ControllerBase
    {
        private readonly InstallationService _installationService;

        public InstallationController(InstallationService installationService)
        {
            _installationService = installationService;
        }
        /// <summary>
        /// Gets a specific Installation object by id.
        /// </summary>
        /// <param name="id">Id of the Installation object</param>
        /// <returns>200 and the Installation object. 404 if not found.</returns>
        [HttpGet]
        [Route("Installation/{id}")]
        [ProducesResponseType(typeof(ViewModels.Installation.Full), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetAsync(int id)
        {
            var installation = await _installationService.GetByIdAsync<ViewModels.Installation.Full>(id);

            if (installation == null)
                return NotFound();

            return Ok(installation);
        }
    }
}