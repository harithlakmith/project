using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TranspotationTicketBooking.Models;
using TranspotationTicketBooking.Models.Users;

namespace TranspotationTicketBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRegistrationModelController : ControllerBase
    {
        private readonly TicketBookingDBContext _context;

        public UserRegistrationModelController(TicketBookingDBContext context)
        {
            _context = context;
        }

        // GET: api/UserRegistrationModel
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserRegistrationModel>>> GetUserRegistrationModel()
        {
            return await _context.UserRegistrationModel.ToListAsync();
        }

        // GET: api/UserRegistrationModel/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserRegistrationModel>> GetUserRegistrationModel(string id)
        {
            var userRegistrationModel = await _context.UserRegistrationModel.FindAsync(id);

            if (userRegistrationModel == null)
            {
                return NotFound();
            }

            return userRegistrationModel;
        }

        // PUT: api/UserRegistrationModel/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserRegistrationModel(string id, UserRegistrationModel userRegistrationModel)
        {
            if (id != userRegistrationModel.NIC)
            {
                return BadRequest();
            }

            _context.Entry(userRegistrationModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserRegistrationModelExists(id))
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

        // POST: api/UserRegistrationModel
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<UserRegistrationModel>> PostUserRegistrationModel(UserRegistrationModel userRegistrationModel)
        {
            _context.UserRegistrationModel.Add(userRegistrationModel);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UserRegistrationModelExists(userRegistrationModel.NIC))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUserRegistrationModel", new { id = userRegistrationModel.NIC }, userRegistrationModel);
        }

        // DELETE: api/UserRegistrationModel/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UserRegistrationModel>> DeleteUserRegistrationModel(string id)
        {
            var userRegistrationModel = await _context.UserRegistrationModel.FindAsync(id);
            if (userRegistrationModel == null)
            {
                return NotFound();
            }

            _context.UserRegistrationModel.Remove(userRegistrationModel);
            await _context.SaveChangesAsync();

            return userRegistrationModel;
        }

        private bool UserRegistrationModelExists(string id)
        {
            return _context.UserRegistrationModel.Any(e => e.NIC == id);
        }
    }
}
