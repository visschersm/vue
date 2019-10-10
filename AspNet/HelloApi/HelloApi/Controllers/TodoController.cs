using HelloApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly TodoContext _context;

        public TodoController(TodoContext context)
        {
            _context = context;

            if (_context.TodoItems.Count() == 0)
            {
                for (int i = 0; i < 10; ++i)
                {
                    _context.TodoItems.Add(new TodoItem { Name = $"Item{i + 1}" });
                }
                _context.SaveChanges();
            }
        }

        /// <summary>
        ///     Gets a list of TodoItems.
        /// </summary>
        /// <remarks>
        ///     This method will only return items that the users making the call has access to.
        /// </remarks>
        /// <returns>List of TodoItems.</returns>
        /// <seealso cref="GetAsync(int)"/>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<TodoItem>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<TodoItem>>> GetAsync()
        {
            return Ok(await _context.TodoItems.ToListAsync());
        }

        /// <summary>
        /// This is my GetAsync method.
        /// </summary>
        /// <param name="id">This is the Id.</param>
        /// <returns>The returned todo item.</returns>
        /// <response code="200">This was a success</response>
        /// <response code="404">Er wordt wel een geldig Id verwacht :p</response>

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(TodoItem), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TodoItem>> GetAsync(int id)
        {
            var todoItem = await _context.TodoItems.FindAsync(id);

            if (todoItem == null)
                return NotFound();

            return Ok(todoItem);
        }



        /// <summary>
        /// This is my Create Method
        /// </summary>
        /// <param name="item">Item to Create</param>
        [HttpPost]
        [ProducesResponseType(typeof(TodoItem), StatusCodes.Status201Created)]
        public async Task<ActionResult<TodoItem>> CreateAsync(ViewModels.TodoItem.Create item)
        {
            var newItem = new TodoItem
            {
                Name = item.Name,
                IsComplete = false,
                CompletedDate = null
            };

            _context.TodoItems.Add(newItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAsync), new { item.Id }, item);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> UpdateAsync(int id, TodoItem item)
        {
            if (id != item.Id)
                return BadRequest();

            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var item = await _context.TodoItems.FindAsync(id);

            if (item == null)
                return NotFound();

            _context.TodoItems.Remove(item);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPatch("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Update(int id, [FromBody] JsonPatchDocument<TodoItem> patchDoc)
        {
            // Json files, with the patch operations.
            // https://tools.ietf.org/html/rfc6902

            if (patchDoc == null)
                return BadRequest(ModelState);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var item = await _context.TodoItems.FindAsync(id);

            if (item == null)
                return NotFound();

            patchDoc.ApplyTo(item, ModelState);

            return NoContent();
        }
    }
}