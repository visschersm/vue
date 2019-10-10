using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using ServiceLayer.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace TestApi.Controllers
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
        [ProducesResponseType(typeof(ModelStateDictionary), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ViewModel.User.Create), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ViewModel.User.Detailed), StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateAsync(ViewModel.User.Create toCreate)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _userService.CreateAsync<ViewModel.User.Detailed>(toCreate);

            if (result == null)
                return BadRequest(toCreate);

            return Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ViewModel.User.Detailed), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var result = await _userService.GetByIdAsync<ViewModel.User.Detailed>(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var result = await _userService.GetAsync<ViewModel.User.List>();

            return Ok(result.ToArray());
        }

        //[HttpPatch]
        //public async Task<IActionResult> PatchAsync()
        //{
        //
        //}

        [HttpPut]
        [ProducesResponseType(typeof(ModelStateDictionary), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ViewModel.User.Update), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ViewModel.User.Detailed), StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateAsync(int id, ViewModel.User.Update toUpdate)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id < 1)
                return BadRequest(id);

            var result = await _userService.UpdateAsync<ViewModel.User.Detailed>(id, toUpdate);

            if (result == null)
                return BadRequest(toUpdate);

            return Ok(result);
        }

        [HttpDelete]
        [ProducesResponseType(typeof(ModelStateDictionary), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _userService.DeleteByIdAsync(id);

            if (result == false)
                return BadRequest();

            return NoContent();
        }
    }
}