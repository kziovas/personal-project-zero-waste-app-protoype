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
    public class NutritionalTypesController : ControllerBase
    {
        private readonly ZeroWasteContext _context;

        public NutritionalTypesController(ZeroWasteContext context)
        {
            _context = context;
        }

        // GET: api/NutritionalTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NutritionalType>>> GetNutritionalType()
        {
            return await _context.NutritionalTypes.ToListAsync();
        }

        // GET: api/NutritionalTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NutritionalType>> GetNutritionalType(long id)
        {
            var nutritionalType = await _context.NutritionalTypes.FindAsync(id);

            if (nutritionalType == null)
            {
                return NotFound();
            }

            return nutritionalType;
        }

        // PUT: api/NutritionalTypes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNutritionalType(long id, NutritionalType nutritionalType)
        {
            if (id != nutritionalType.ID)
            {
                return BadRequest();
            }

            _context.Entry(nutritionalType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NutritionalTypeExists(id))
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

        // POST: api/NutritionalTypes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<NutritionalType>> PostNutritionalType(NutritionalType nutritionalType)
        {
            _context.NutritionalTypes.Add(nutritionalType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNutritionalType", new { id = nutritionalType.ID }, nutritionalType);
        }

        // DELETE: api/NutritionalTypes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<NutritionalType>> DeleteNutritionalType(long id)
        {
            var nutritionalType = await _context.NutritionalTypes.FindAsync(id);
            if (nutritionalType == null)
            {
                return NotFound();
            }

            _context.NutritionalTypes.Remove(nutritionalType);
            await _context.SaveChangesAsync();

            return nutritionalType;
        }

        private bool NutritionalTypeExists(long id)
        {
            return _context.NutritionalTypes.Any(e => e.ID == id);
        }
    }
}
