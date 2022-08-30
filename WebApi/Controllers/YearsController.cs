﻿using System;
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
    public class YearsController : ControllerBase
    {
        private readonly RentManagerContext _context;

        public YearsController(RentManagerContext context)
        {
            _context = context;
        }

        // GET: api/Years
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Year>>> GetYears()
        {
          if (_context.Years == null)
          {
              return NotFound();
          }
            return await _context.Years.ToListAsync();
        }

        // GET: api/Years/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Year>> GetYear(int id)
        {
          if (_context.Years == null)
          {
              return NotFound();
          }
            var year = await _context.Years.FindAsync(id);

            if (year == null)
            {
                return NotFound();
            }

            return year;
        }

        // PUT: api/Years/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutYear(int id, Year year)
        {
            if (id != year.YearId)
            {
                return BadRequest();
            }

            _context.Entry(year).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!YearExists(id))
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

        // POST: api/Years
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Year>> PostYear(Year year)
        {
          if (_context.Years == null)
          {
              return Problem("Entity set 'DataContext.Years'  is null.");
          }
            _context.Years.Add(year);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetYear", new { id = year.YearId }, year);
        }

        // DELETE: api/Years/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteYear(int id)
        {
            if (_context.Years == null)
            {
                return NotFound();
            }
            var year = await _context.Years.FindAsync(id);
            if (year == null)
            {
                return NotFound();
            }

            _context.Years.Remove(year);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool YearExists(int id)
        {
            return (_context.Years?.Any(e => e.YearId == id)).GetValueOrDefault();
        }
    }
}
