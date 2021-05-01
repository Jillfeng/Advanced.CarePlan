using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Advanced.CarePlan.API.Data;
using Advanced.CarePlan.API.Models;

namespace Advanced.CarePlan.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarePlansController : ControllerBase
    {
        private readonly CarePlanContext _context;

        public CarePlansController(CarePlanContext context)
        {
            _context = context;
        }

        // GET: api/CarePlans
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Models.CarePlan>>> GetCarePlan()
        {
            return await _context.CarePlan.ToListAsync();
        }

        // GET: api/CarePlans/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Models.CarePlan>> GetCarePlan(int id)
        {
            var carePlan = await _context.CarePlan.FindAsync(id);

            if (carePlan == null)
            {
                return NotFound();
            }

            return carePlan;
        }

        // PUT: api/CarePlans/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCarePlan(int id, Models.CarePlan carePlan)
        {
            if (id != carePlan.CarePlanId)
            {
                return BadRequest();
            }

            _context.Entry(carePlan).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarePlanExists(id))
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

        // POST: api/CarePlans
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Models.CarePlan>> PostCarePlan(Models.CarePlan carePlan)
        {
            _context.CarePlan.Add(carePlan);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCarePlan", new { id = carePlan.CarePlanId }, carePlan);
        }

        // DELETE: api/CarePlans/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Models.CarePlan>> DeleteCarePlan(int id)
        {
            var carePlan = await _context.CarePlan.FindAsync(id);
            if (carePlan == null)
            {
                return NotFound();
            }

            _context.CarePlan.Remove(carePlan);
            await _context.SaveChangesAsync();

            return carePlan;
        }

        private bool CarePlanExists(int id)
        {
            return _context.CarePlan.Any(e => e.CarePlanId == id);
        }
    }
}
