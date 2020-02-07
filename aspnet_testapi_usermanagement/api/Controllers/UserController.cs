using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Interfaces;
using System.Threading.Tasks;

namespace api.Controllers
{
    /// <summary>
    /// Controller to handle all the User related Requests.
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        /// <summary>
        /// To Construct the UserController a instance of the IUserService has to be provided.
        /// </summary>
        /// <param name="userService">The instance of the IUserService.</param>
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Creates a new User Object.
        /// </summary>
        /// <param name="model">The CreateView to create the User from.</param>
        /// <returns>
        /// 400 if the given model is invalid.
        /// 500 if the User was not created correctly.
        /// 200 with a Simple UserView.
        /// </returns>
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