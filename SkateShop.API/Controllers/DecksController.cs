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
    public class DecksController : Controller
    {
        private readonly SkateboardContext _context;

        public DecksController(SkateboardContext context)
        {
            _context = context;
        }
     
        [HttpGet]
        public List<Deck> GetDecks()
        {
            List<Deck> model = _context.Deck.ToList();
            return model;
        }

        // GET: api/Decks/5
        [HttpGet("{id}")]
        public Deck GetDeck(int id)
        {
            Deck model = _context.Deck.Find(id);
            return model;
        }

        // PUT: api/Decks/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDeck(int id, Deck deck)
        {
            if (id != deck.Id)
            {
                return BadRequest();
            }

            _context.Entry(deck).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeckExists(id))
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

        // POST: api/Decks
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public string AddDeck(Deck deck)
        {
            try
            {
                _context.Deck.Add(deck);
                _context.SaveChanges();
                return "successs";

            }
            catch (Exception e )
            {
                return e+"Error";
            }
        }

        // DELETE: api/Decks/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Deck>> DeleteDeck(int id)
        {
            var deck = await _context.Deck.FindAsync(id);
            if (deck == null)
            {
                return NotFound();
            }

            _context.Deck.Remove(deck);
            await _context.SaveChangesAsync();

            return deck;
        }

        private bool DeckExists(int id)
        {
            return _context.Deck.Any(e => e.Id == id);
        }
    }
}
