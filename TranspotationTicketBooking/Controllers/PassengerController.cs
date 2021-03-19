using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TranspotationTicketBooking.Models;

namespace TranspotationTicketBooking.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PassengerController : ControllerBase
    {
        private readonly TicketBookingDBContext _context;

        public PassengerController(TicketBookingDBContext context)
        {
            _context = context;
        }

        // GET: api/Passenger
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Passenger>>> GetPassenger()
        {
            return await _context.Passenger.ToListAsync();
        }

        // GET: api/Passenger/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Passenger>> GetPassenger(long id)
        {
            var passenger = await _context.Passenger.FindAsync(id);

            if (passenger == null)
            {
                return NotFound();
            }

            return passenger;
        }

        // PUT: api/Passenger/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPassenger(long id, Passenger passenger)
        {
            if (id != passenger.PId)
            {
                return BadRequest();
            }

            _context.Entry(passenger).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PassengerExists(id))
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

        // POST: api/Passenger
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        /*[HttpPost]
        public async Task<ActionResult<Passenger>> PostPassenger(Passenger passenger)
        {
            _context.Passenger.Add(passenger);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPassenger", new { id = passenger.PId }, passenger);
        }*/

        // DELETE: api/Passenger/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Passenger>> DeletePassenger(long id)
        {
            var passenger = await _context.Passenger.FindAsync(id);
            if (passenger == null)
            {
                return NotFound();
            }

            _context.Passenger.Remove(passenger);
            await _context.SaveChangesAsync();

            return passenger;
        }

        private bool PassengerExists(long id)
        {
            return _context.Passenger.Any(e => e.PId == id);
        }
    }
}
