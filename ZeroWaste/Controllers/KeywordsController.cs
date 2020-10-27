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
    public class KeywordsController : ControllerBase
    {
        private readonly ZeroWasteContext _context;

        public KeywordsController(ZeroWasteContext context)
        {
            _context = context;
        }

        // GET: api/Keywords
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Keyword>>> GetKeyword()
        {
            return await _context.Keywords.ToListAsync();
        }

        // GET: api/Keywords/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Keyword>> GetKeyword(long id)
        {
            var keyword = await _context.Keywords.FindAsync(id);

            if (keyword == null)
            {
                return NotFound();
            }

            return keyword;
        }

        // PUT: api/Keywords/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKeyword(long id, Keyword keyword)
        {
            if (id != keyword.ID)
            {
                return BadRequest();
            }

            _context.Entry(keyword).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KeywordExists(id))
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

        // POST: api/Keywords
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Keyword>> PostKeyword(Keyword keyword)
        {
            _context.Keywords.Add(keyword);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetKeyword", new { id = keyword.ID }, keyword);
        }

        // DELETE: api/Keywords/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Keyword>> DeleteKeyword(long id)
        {
            var keyword = await _context.Keywords.FindAsync(id);
            if (keyword == null)
            {
                return NotFound();
            }

            _context.Keywords.Remove(keyword);
            await _context.SaveChangesAsync();

            return keyword;
        }

        private bool KeywordExists(long id)
        {
            return _context.Keywords.Any(e => e.ID == id);
        }
    }
}
