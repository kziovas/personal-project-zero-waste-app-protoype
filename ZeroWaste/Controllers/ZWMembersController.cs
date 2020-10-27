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
    public class ZWMembersController : ControllerBase
    {
        private readonly ZeroWasteContext _context;

        public ZWMembersController(ZeroWasteContext context)
        {
            _context = context;
        }

        // GET: api/ZWMembers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ZWMember>>> GetZWMember()
        {
            return await _context.ZWMembers.ToListAsync();
        }

        // GET: api/ZWMembers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ZWMember>> GetZWMember(long id)
        {
            var zWMember = await _context.ZWMembers.FindAsync(id);

            if (zWMember == null)
            {
                return NotFound();
            }

            return zWMember;
        }

        // PUT: api/ZWMembers/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutZWMember(long id, ZWMember zWMember)
        {
            if (id != zWMember.ID)
            {
                return BadRequest();
            }

            _context.Entry(zWMember).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ZWMemberExists(id))
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

        // POST: api/ZWMembers
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ZWMember>> PostZWMember(ZWMember zWMember)
        {
            _context.ZWMembers.Add(zWMember);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetZWMember", new { id = zWMember.ID }, zWMember);
        }

        // DELETE: api/ZWMembers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ZWMember>> DeleteZWMember(long id)
        {
            var zWMember = await _context.ZWMembers.FindAsync(id);
            if (zWMember == null)
            {
                return NotFound();
            }

            _context.ZWMembers.Remove(zWMember);
            await _context.SaveChangesAsync();

            return zWMember;
        }

        private bool ZWMemberExists(long id)
        {
            return _context.ZWMembers.Any(e => e.ID == id);
        }
    }
}
