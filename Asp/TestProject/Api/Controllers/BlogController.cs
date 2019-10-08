using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly BlogService _blogService;

        public BlogController(BlogService blogService)
        {
            _blogService = blogService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ViewModels.Blog.List>), StatusCodes.Status200OK)]
        public IActionResult Get()
        {
            var result = _blogService.GetAsync<ViewModels.Blog.List>();

            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ViewModels.Blog.Full), StatusCodes.Status200OK)]
        public async Task<ActionResult<ViewModels.Blog.Full>> CreateAsync(ViewModels.Blog.Create newBlog)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var result = await _blogService.CreateAsync<ViewModels.Blog.Full>(newBlog);

            return Ok(result);
        }
    }
}