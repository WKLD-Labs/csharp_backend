using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using csharp_backend;
using csharp_backend.Models;

namespace csharp_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DummiesController : ControllerBase
    {
        private readonly LabsContext _context;

        public DummiesController(LabsContext context)
        {
            _context = context;
        }

        // GET: api/Dummies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dummy>>> GetDummies()
        {
            return await _context.Dummies.ToListAsync();
        }

        // GET: api/Dummies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Dummy>> GetDummy(int id)
        {
            var dummy = await _context.Dummies.FindAsync(id);

            if (dummy == null)
            {
                return NotFound();
            }

            return dummy;
        }

        // PUT: api/Dummies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDummy(int id, Dummy dummy)
        {
            if (id != dummy.DummyId)
            {
                return BadRequest();
            }

            _context.Entry(dummy).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DummyExists(id))
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

        // POST: api/Dummies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Dummy>> PostDummy(Dummy dummy)
        {
            _context.Dummies.Add(dummy);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDummy", new { id = dummy.DummyId }, dummy);
        }

        // DELETE: api/Dummies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDummy(int id)
        {
            var dummy = await _context.Dummies.FindAsync(id);
            if (dummy == null)
            {
                return NotFound();
            }

            _context.Dummies.Remove(dummy);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DummyExists(int id)
        {
            return _context.Dummies.Any(e => e.DummyId == id);
        }
    }
}
