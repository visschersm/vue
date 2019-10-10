using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewModels;
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

        [HttpGet]
        [Route("Installation")]
        [ProducesResponseType(typeof(ResponseObject<List<ViewModels.Installation.List>>), 200)]
        public async Task<IActionResult> GetAsync(Meta meta)
        {
            var filters = Request.Query.ToDictionary(x => x.Key.ToLowerInvariant(), x => string.Join(",", x.Value));
            var installations = (await _installationService.GetAsync<ViewModels.Installation.List>(meta.PageSize, meta.PageIndex - 1, meta.Sort)).ToList();
            meta.PageTotal = await _installationService.GetTotalAsync();

            if (meta.PageIndex < 1)
                return BadRequest("Page Index query parameter must be greater than 0.");

            return Ok(new ResponseObject<List<ViewModels.Installation.List>>
            {
                Meta = meta,
                Data = installations
            });
        }

        /// <summary>
        /// Gets a specific Installation object by id.
        /// </summary>
        /// <param name="id">Id of the Installation object</param>
        /// <returns>200 and the Installation object. 404 if not found.</returns>
        [HttpGet]
        [Route("Installation/{id}")]
        [Authorize(Policy = "AuthenticatedUserOrAppAdminOrOgcRead")]
        [ProducesResponseType(typeof(ViewModels.Installation.Full), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetAsync(string id)
        {
            var installation = _installationService.GetByIdAsync<ViewModels.Installation.Full>(id);

            if (installation == null)
                return NotFound();

            return Ok(installation);
        }
    }
}