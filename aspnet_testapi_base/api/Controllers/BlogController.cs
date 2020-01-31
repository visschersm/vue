using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Interfaces;
using System;
using System.Threading.Tasks;
using Blogs = ServiceLayer.Blogs;

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
        [ProducesResponseType(typeof(Blogs.Views.Simple), StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateAsync([FromBody]Blogs.Views.Create create)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var result = await _blogService.CreateAsync<Blogs.Views.Create, Blogs.Views.Simple>(create);

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
        [ProducesResponseType(typeof(Blogs.Views.Full), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var result = await _blogService.GetByIdAsync<Guid, Blogs.Views.Full>(id);

            if (result == null)
                return BadRequest($"Could not get blog with: {nameof(id)}: {id}");

            return Ok(result);
        }

        [HttpGet]
        [ProducesResponseType(typeof(Blogs.Views.List[]), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAsync()
        {
            var result = await _blogService.GetAsync<Blogs.Views.List>(
                select: x => new Blogs.Views.List
                {
                    Id = x.Id
                });

            return Ok(result);
        }
    }
}