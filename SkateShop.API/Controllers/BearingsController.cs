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
    public class BearingsController : ControllerBase
    {
        private readonly SkateboardContext _context;

        public BearingsController(SkateboardContext context)
        {
            _context = context;
        }

        // GET: api/Bearings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bearing>>> GetBearing()
        {
            return await _context.Bearing.ToListAsync();
        }

        // GET: api/Bearings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Bearing>> GetBearing(int id)
        {
            var bearing = await _context.Bearing.FindAsync(id);

            if (bearing == null)
            {
                return NotFound();
            }

            return bearing;
        }

        // PUT: api/Bearings/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBearing(int id, Bearing bearing)
        {
            if (id != bearing.Id)
            {
                return BadRequest();
            }

            _context.Entry(bearing).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BearingExists(id))
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

        // POST: api/Bearings
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Bearing>> PostBearing(Bearing bearing)
        {
            _context.Bearing.Add(bearing);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBearing", new { id = bearing.Id }, bearing);
        }

        // DELETE: api/Bearings/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Bearing>> DeleteBearing(int id)
        {
            var bearing = await _context.Bearing.FindAsync(id);
            if (bearing == null)
            {
                return NotFound();
            }

            _context.Bearing.Remove(bearing);
            await _context.SaveChangesAsync();

            return bearing;
        }

        private bool BearingExists(int id)
        {
            return _context.Bearing.Any(e => e.Id == id);
        }
    }
}
