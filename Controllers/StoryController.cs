using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using gamocracy.Models;

namespace gamocracy.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StoryController : ControllerBase
    {
        private readonly StoryContext _context;

        public StoryController(StoryContext context)
        {
            _context = context;
        }

        // GET: Story
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Story>>> GetStories()
        {
            return await _context.Stories.ToListAsync();
        }

        // GET: Story/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Story>> GetStory(int id)
        {
            var story = await _context.Stories.FindAsync(id);

            if (story == null)
            {
                return NotFound();
            }

            return story;
        }

        // PUT: Story/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStory(int id, Story story)
        {
            if (id != story.StoryId)
            {
                return BadRequest();
            }

            _context.Entry(story).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StoryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: Story
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Story>> PostStory(Story story)
        {
            _context.Stories.Add(story);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStory", new { id = story.StoryId }, story);
        }

        // // DELETE: Story/5
        // [HttpDelete("{id}")]
        // public async Task<ActionResult<Story>> DeleteStory(int id)
        // {
        //     var story = await _context.Stories.FindAsync(id);
        //     if (story == null)
        //     {
        //         return NotFound();
        //     }

        //     _context.Stories.Remove(story);
        //     await _context.SaveChangesAsync();

        //     return story;
        // }

        private bool StoryExists(int id)
        {
            return _context.Stories.Any(e => e.StoryId == id);
        }
    }
}
