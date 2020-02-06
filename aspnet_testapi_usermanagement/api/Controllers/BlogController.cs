using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Interfaces;
using System;
using System.Threading.Tasks;

namespace api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly IBlogService _blogService;

        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ViewModels.Blogs.Simple), StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateAsync([FromBody]ViewModels.Blogs.Create create)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var result = await _blogService.CreateAsync<ViewModels.Blogs.Create, ViewModels.Blogs.Simple>(create);

                if (result == null)
                    return BadRequest("Could not create blog");

                return Ok(result);
            }
            catch (AutoMapperMappingException exception)
            {
                return BadRequest(exception);
            }
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ViewModels.Blogs.Full), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var result = await _blogService.GetByIdAsync<Guid, ViewModels.Blogs.Full>(id);

            if (result == null)
                return BadRequest($"Could not get blog with: {nameof(id)}: {id}");

            return Ok(result);
        }

        [HttpGet]
        [ProducesResponseType(typeof(ViewModels.Blogs.List[]), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAsync()
        {
            var result = await _blogService.GetAsync<ViewModels.Blogs.List>(
                select: x => new ViewModels.Blogs.List
                {
                    Id = x.Id
                });

            return Ok(result);
        }
    }
}