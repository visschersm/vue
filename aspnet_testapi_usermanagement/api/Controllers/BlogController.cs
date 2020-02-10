using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Interfaces;
using System;
using System.Threading.Tasks;

namespace api.Controllers
{
    /// <summary>
    /// Controller to handle all the Blog related Requests.
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly IBlogService _blogService;

        /// <summary>
        /// To construct the BlogController a instance of the IBlogService interface has to be provided.
        /// </summary>
        /// <param name="blogService">An instance of the IBlogService interface.</param>
        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        /// <summary>
        /// Creates a new Blog
        /// </summary>
        /// <param name="create">The creationView from which the new Blog is created.</param>
        /// <returns>
        /// 400 if the ModelState is invalid.
        /// 400 if the Mapping is missing.
        /// 200 with a Simple BlogView when the Blog is created succesfully.
        /// </returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ViewModels.Blogs.Simple), StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateAsync([FromBody]ViewModels.Blogs.Create create)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var result = await _blogService.CreateAsync<ViewModels.Blogs.Simple>(create);

                if (result == null)
                    return BadRequest("Could not create blog");

                return Ok(result);
            }
            catch (AutoMapperMappingException exception)
            {
                return BadRequest(exception);
            }
        }

        /// <summary>
        /// Gets the Blog with a specific Id.
        /// </summary>
        /// <param name="id">The Id of the specific Blog</param>
        /// <returns>
        /// 404 when blog with id param is not found.
        /// 200 With a Full BlogView if a Blog with the id param is found.
        /// </returns>
        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ViewModels.Blogs.Full), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var result = await _blogService.GetByIdAsync<ViewModels.Blogs.Full>(id);

            if (result == null)
                return NotFound($"Could not get blog with: {nameof(id)}: {id}");

            return Ok(result);
        }

        /// <summary>
        /// Gets all the Blog Objects.
        /// </summary>
        /// <returns>
        /// 200 with a List of List BlogViews.
        /// </returns>
        [HttpGet]
        [ProducesResponseType(typeof(ViewModels.Blogs.List[]), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAsync()
        {
            var result = await _blogService.GetAsync<ViewModels.Blogs.List>();

            return Ok(result);
        }

        /// <summary>
        /// Updates a specific Blog with a given Id.
        /// </summary>
        /// <param name="id">The Id of a specific Blog object.</param>
        /// <param name="updateView">The view of the blog with updated values.</param>
        /// <returns>
        /// 400 if given update view is not valid.
        /// 500 if something went wrong updating the Blog.
        /// 200 with the updated full BlogView.
        /// </returns>
        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(typeof(ViewModels.Blogs.Full), StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateAsync(Guid id, [FromBody]ViewModels.Blogs.Update updateView)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _blogService.UpdateAsync<ViewModels.Blogs.Full>(id, updateView);

            if (result == null)
                return StatusCode(StatusCodes.Status500InternalServerError, $"Could not update Blog with {nameof(updateView)}: {updateView}");

            return Ok(result);
        }

        /// <summary>
        /// Delete the Blog with the given Id
        /// </summary>
        /// <param name="id">The id of the Blog to delete.</param>
        /// <returns>
        /// 500 if the Blog could not be deleted.
        /// 204 if the Blog is deleted successfully.
        /// </returns>
        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            try
            {
                var result = await _blogService.DeleteAsync(id);

                if (!result)
                    return StatusCode(StatusCodes.Status500InternalServerError, $"Could not delete the Blog with {nameof(id)}: {id}");

                return StatusCode(StatusCodes.Status204NoContent);
            }
            catch (ArgumentNullException)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Could not delete the Blog with {nameof(id)}: {id}");
                throw;
            }
        }
    }
}