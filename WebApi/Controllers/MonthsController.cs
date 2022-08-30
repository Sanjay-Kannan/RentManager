using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MonthsController : ControllerBase
    {
        private readonly RentManagerContext _context;

        public MonthsController(RentManagerContext context)
        {
            _context = context;
        }

        // GET: api/Months
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Month>>> GetMonths()
        {
          if (_context.Months == null)
          {
              return NotFound();
          }
            return await _context.Months.ToListAsync();
        }

        // GET: api/Months/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Month>> GetMonth(int id)
        {
          if (_context.Months == null)
          {
              return NotFound();
          }
            var month = await _context.Months.FindAsync(id);

            if (month == null)
            {
                return NotFound();
            }

            return month;
        }

        // PUT: api/Months/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMonth(int id, Month month)
        {
            if (id != month.MonthId)
            {
                return BadRequest();
            }

            _context.Entry(month).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MonthExists(id))
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

        // POST: api/Months
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Month>> PostMonth(Month month)
        {
          if (_context.Months == null)
          {
              return Problem("Entity set 'DataContext.Months'  is null.");
          }
            _context.Months.Add(month);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMonth", new { id = month.MonthId }, month);
        }

        // DELETE: api/Months/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMonth(int id)
        {
            if (_context.Months == null)
            {
                return NotFound();
            }
            var month = await _context.Months.FindAsync(id);
            if (month == null)
            {
                return NotFound();
            }

            _context.Months.Remove(month);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MonthExists(int id)
        {
            return (_context.Months?.Any(e => e.MonthId == id)).GetValueOrDefault();
        }
    }
}
