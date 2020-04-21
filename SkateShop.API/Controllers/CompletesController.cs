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
    public class CompletesController : ControllerBase
    {
        private readonly SkateboardContext _context;

        public CompletesController(SkateboardContext context)
        {
            _context = context;
        }

        // GET: api/Completes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Complete>>> GetComplete()
        {
            return await _context.Complete.ToListAsync();
        }

        // GET: api/Completes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Complete>> GetComplete(int id)
        {
            var complete = await _context.Complete.FindAsync(id);

            if (complete == null)
            {
                return NotFound();
            }

            return complete;
        }

        // PUT: api/Completes/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutComplete(int id, Complete complete)
        {
            if (id != complete.Id)
            {
                return BadRequest();
            }

            _context.Entry(complete).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompleteExists(id))
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

        // POST: api/Completes
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Complete>> PostComplete(Complete complete)
        {
            _context.Complete.Add(complete);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetComplete", new { id = complete.Id }, complete);
        }

        // DELETE: api/Completes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Complete>> DeleteComplete(int id)
        {
            var complete = await _context.Complete.FindAsync(id);
            if (complete == null)
            {
                return NotFound();
            }

            _context.Complete.Remove(complete);
            await _context.SaveChangesAsync();

            return complete;
        }

        private bool CompleteExists(int id)
        {
            return _context.Complete.Any(e => e.Id == id);
        }
    }
}
