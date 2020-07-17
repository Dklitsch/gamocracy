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
    [Route("api/[controller]")]
    [ApiController]
    public class SceneController : ControllerBase
    {
        private readonly GamocracyContext _context;

        public SceneController(GamocracyContext context)
        {
            _context = context;
        }

        // GET: api/Scene
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Scene>>> GetScenes()
        {
            return await _context.Scenes.ToListAsync();
        }

        // GET: api/Scene/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Scene>> GetScene(int id)
        {
            var scene = await _context.Scenes.FindAsync(id);

            if (scene == null)
            {
                return NotFound();
            }

            return scene;
        }

        // PUT: api/Scene/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutScene(int id, Scene scene)
        {
            if (id != scene.SceneId)
            {
                return BadRequest();
            }

            _context.Entry(scene).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SceneExists(id))
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

        // POST: api/Scene
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Scene>> PostScene(Scene scene)
        {
            _context.Scenes.Add(scene);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetScene", new { id = scene.SceneId }, scene);
        }

        // DELETE: api/Scene/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Scene>> DeleteScene(int id)
        {
            var scene = await _context.Scenes.FindAsync(id);
            if (scene == null)
            {
                return NotFound();
            }

            _context.Scenes.Remove(scene);
            await _context.SaveChangesAsync();

            return scene;
        }

        private bool SceneExists(int id)
        {
            return _context.Scenes.Any(e => e.SceneId == id);
        }
    }
}
