using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SkateShop.Data;
using SkateShop.Domain;

namespace SkateShop.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class GriptapesController : ControllerBase
    {
        private readonly SkateboardContext _context;

        public GriptapesController(SkateboardContext context)
        {
            _context = context;
        }

        // GET: api/Griptapes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Griptape>>> GetGripTape()
        {
            return await _context.GripTape.ToListAsync();
        }

        // GET: api/Griptapes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Griptape>> GetGriptape(int id)
        {
            var griptape = await _context.GripTape.FindAsync(id);

            if (griptape == null)
            {
                return NotFound();
            }

            return griptape;
        }

        // PUT: api/Griptapes/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGriptape(int id, Griptape griptape)
        {
            if (id != griptape.Id)
            {
                return BadRequest();
            }

            _context.Entry(griptape).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GriptapeExists(id))
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

        // POST: api/Griptapes
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Griptape>> PostGriptape(Griptape griptape)
        {
            _context.GripTape.Add(griptape);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGriptape", new { id = griptape.Id }, griptape);
        }

        // DELETE: api/Griptapes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Griptape>> DeleteGriptape(int id)
        {
            var griptape = await _context.GripTape.FindAsync(id);
            if (griptape == null)
            {
                return NotFound();
            }

            _context.GripTape.Remove(griptape);
            await _context.SaveChangesAsync();

            return griptape;
        }

        private bool GriptapeExists(int id)
        {
            return _context.GripTape.Any(e => e.Id == id);
        }
    }
}
