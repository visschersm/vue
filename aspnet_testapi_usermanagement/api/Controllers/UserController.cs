using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Interfaces;
using System;
using System.Linq;
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
        /// <param name="createView">The CreateView to create the User from.</param>
        /// <returns>
        /// 400 if the given model is invalid.
        /// 500 if the User was not created correctly.
        /// 200 with a Simple UserView.
        /// </returns>
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody]ViewModels.Users.Create createView)
        {
            if (!ModelState.IsValid)
                return BadRequest(createView);

            var result = await _userService.CreateAsync<ViewModels.Users.Simple>(createView);

            if (result.Item1 == null)
            {
                var errors = string.Join("\n", result.Item2.Select(x => x.Description));
                return StatusCode(StatusCodes.Status500InternalServerError, $"could not create the user with given view: {createView}.\n{errors}");
            }


            return Ok(result.Item1);
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var result = await _userService.GetAsync<ViewModels.Users.List>();

            return Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var result = await _userService.GetByIdAsync<ViewModels.Users.Full>(id);

            if (result == null)
                return NotFound($"User with {nameof(id)}: {id} not found.");

            return Ok(result);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateAsync(Guid id, [FromBody]ViewModels.Users.Update updateView)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _userService.UpdateAsync<ViewModels.Users.Full>(id, updateView);

            if (result == null)
                return StatusCode(StatusCodes.Status500InternalServerError, $"Could not update Blog with {nameof(updateView)}: {updateView}");

            return Ok(result);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            try
            {
                var result = await _userService.DeleteAsync(id);

                if (!result)
                    return StatusCode(StatusCodes.Status500InternalServerError, $"Could not delete the User with {nameof(id)}: {id}");

                return StatusCode(StatusCodes.Status204NoContent);
            }
            catch (ArgumentNullException)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Could not delete the User with {nameof(id)}: {id}");
                throw;
            }
        }

        /*[AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<IActionResult> AuthenticateAsync([FromBody]ViewModels.Users.Authenticate model)
        {
            var user = await _userService.AuthenticateAsync(model);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(user);
        }*/
    }
}