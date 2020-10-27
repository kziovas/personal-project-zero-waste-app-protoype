using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZeroWaste.Data;
using ZeroWaste.Models;

namespace ZeroWaste.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipiesController : ControllerBase
    {
        private readonly ZeroWasteContext _context;

        public RecipiesController(ZeroWasteContext context)
        {
            _context = context;
        }

        // GET: api/Recipies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Recipie>>> GetRecipie()
        {
            return await _context.Recipies.ToListAsync();
        }

        // GET: api/Recipies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Recipie>> GetRecipie(long id)
        {
            var recipie = await _context.Recipies.FindAsync(id);

            if (recipie == null)
            {
                return NotFound();
            }

            return recipie;
        }

        // PUT: api/Recipies/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRecipie(long id, Recipie recipie)
        {
            if (id != recipie.Id)
            {
                return BadRequest();
            }

            _context.Entry(recipie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecipieExists(id))
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

        // POST: api/Recipies
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Recipie>> PostRecipie(Recipie recipie)
        {
            _context.Recipies.Add(recipie);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRecipie", new { id = recipie.Id }, recipie);
        }

        // DELETE: api/Recipies/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Recipie>> DeleteRecipie(long id)
        {
            var recipie = await _context.Recipies.FindAsync(id);
            if (recipie == null)
            {
                return NotFound();
            }

            _context.Recipies.Remove(recipie);
            await _context.SaveChangesAsync();

            return recipie;
        }

        private bool RecipieExists(long id)
        {
            return _context.Recipies.Any(e => e.Id == id);
        }
    }
}
