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
    public class AllergiesController : ControllerBase
    {
        private readonly ZeroWasteContext _context;

        public AllergiesController(ZeroWasteContext context)
        {
            _context = context;
        }

        // GET: api/Allergies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Allergy>>> GetAllergy()
        {
            return await _context.Allergies.ToListAsync();
        }

        // GET: api/Allergies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Allergy>> GetAllergy(long id)
        {
            var allergy = await _context.Allergies.FindAsync(id);

            if (allergy == null)
            {
                return NotFound();
            }

            return allergy;
        }

        // PUT: api/Allergies/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAllergy(long id, Allergy allergy)
        {
            if (id != allergy.ID)
            {
                return BadRequest();
            }

            _context.Entry(allergy).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AllergyExists(id))
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

        // POST: api/Allergies
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Allergy>> PostAllergy(Allergy allergy)
        {
            _context.Allergies.Add(allergy);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAllergy", new { id = allergy.ID }, allergy);
        }

        // DELETE: api/Allergies/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Allergy>> DeleteAllergy(long id)
        {
            var allergy = await _context.Allergies.FindAsync(id);
            if (allergy == null)
            {
                return NotFound();
            }

            _context.Allergies.Remove(allergy);
            await _context.SaveChangesAsync();

            return allergy;
        }

        private bool AllergyExists(long id)
        {
            return _context.Allergies.Any(e => e.ID == id);
        }
    }
}
