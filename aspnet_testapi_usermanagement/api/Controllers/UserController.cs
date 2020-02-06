using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Interfaces;
using System.Threading.Tasks;

namespace api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(ViewModels.Users.Create model)
        {
            if (!ModelState.IsValid)
                return BadRequest(model);

            var result = await _userService.CreateAsync<ViewModels.Users.Create, ViewModels.Users.Simple>(model);

            if (result == null)
                return StatusCode(StatusCodes.Status500InternalServerError);

            return Ok(result);
        }
    }
}