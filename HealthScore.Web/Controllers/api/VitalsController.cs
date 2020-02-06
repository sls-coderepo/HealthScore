using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HealthScore.Web.Data;
using HealthScore.Web.Models;

namespace HealthScore.Web.Controllers.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class VitalsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public VitalsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Vitals
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vital>>> GetVital()
        {
            return await _context.Vital.ToListAsync();
        }

        // GET: api/Vitals/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Vital>> GetVital(int id)
        {
            var vital = await _context.Vital.FindAsync(id);

            if (vital == null)
            {
                return NotFound();
            }

            return vital;
        }

        // PUT: api/Vitals/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVital(int id, Vital vital)
        {
            if (id != vital.Id)
            {
                return BadRequest();
            }

            _context.Entry(vital).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VitalExists(id))
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

        // POST: api/Vitals
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Vital>> PostVital(Vital vital)
        {
            _context.Vital.Add(vital);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVital", new { id = vital.Id }, vital);
        }

        // DELETE: api/Vitals/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Vital>> DeleteVital(int id)
        {
            var vital = await _context.Vital.FindAsync(id);
            if (vital == null)
            {
                return NotFound();
            }

            _context.Vital.Remove(vital);
            await _context.SaveChangesAsync();

            return vital;
        }

        private bool VitalExists(int id)
        {
            return _context.Vital.Any(e => e.Id == id);
        }
    }
}
