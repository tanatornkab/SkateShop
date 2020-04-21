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
    public class AccessoriesController : ControllerBase
    {
        private readonly SkateboardContext _context;

        public AccessoriesController(SkateboardContext context)
        {
            _context = context;
        }

        // GET: api/Accessories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Accessory>>> GetAccessory()
        {
            return await _context.Accessory.ToListAsync();
        }

        // GET: api/Accessories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Accessory>> GetAccessory(int id)
        {
            var accessory = await _context.Accessory.FindAsync(id);

            if (accessory == null)
            {
                return NotFound();
            }

            return accessory;
        }

        // PUT: api/Accessories/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAccessory(int id, Accessory accessory)
        {
            if (id != accessory.Id)
            {
                return BadRequest();
            }

            _context.Entry(accessory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccessoryExists(id))
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

        // POST: api/Accessories
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Accessory>> PostAccessory(Accessory accessory)
        {
            _context.Accessory.Add(accessory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAccessory", new { id = accessory.Id }, accessory);
        }

        // DELETE: api/Accessories/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Accessory>> DeleteAccessory(int id)
        {
            var accessory = await _context.Accessory.FindAsync(id);
            if (accessory == null)
            {
                return NotFound();
            }

            _context.Accessory.Remove(accessory);
            await _context.SaveChangesAsync();

            return accessory;
        }

        private bool AccessoryExists(int id)
        {
            return _context.Accessory.Any(e => e.Id == id);
        }
    }
}
