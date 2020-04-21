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
    public class WheelsController : ControllerBase
    {
        private readonly SkateboardContext _context;

        public WheelsController(SkateboardContext context)
        {
            _context = context;
        }

        // GET: api/Wheels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Wheel>>> GetWheel()
        {
            return await _context.Wheel.ToListAsync();
        }

        // GET: api/Wheels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Wheel>> GetWheel(int id)
        {
            var wheel = await _context.Wheel.FindAsync(id);

            if (wheel == null)
            {
                return NotFound();
            }

            return wheel;
        }

        // PUT: api/Wheels/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWheel(int id, Wheel wheel)
        {
            if (id != wheel.Id)
            {
                return BadRequest();
            }

            _context.Entry(wheel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WheelExists(id))
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

        // POST: api/Wheels
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Wheel>> PostWheel(Wheel wheel)
        {
            _context.Wheel.Add(wheel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWheel", new { id = wheel.Id }, wheel);
        }

        // DELETE: api/Wheels/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Wheel>> DeleteWheel(int id)
        {
            var wheel = await _context.Wheel.FindAsync(id);
            if (wheel == null)
            {
                return NotFound();
            }

            _context.Wheel.Remove(wheel);
            await _context.SaveChangesAsync();

            return wheel;
        }

        private bool WheelExists(int id)
        {
            return _context.Wheel.Any(e => e.Id == id);
        }
    }
}
