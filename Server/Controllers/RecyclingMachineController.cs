using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Models;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecyclingMachineController : ControllerBase
    {
        private readonly ServerContext _context;

        public RecyclingMachineController(ServerContext context)
        {
            _context = context;
        }

        // GET: api/RecyclingMachine
        [HttpGet]
        public IEnumerable<RecyclingMachine> GetRecyclingMachine()
        {
            return _context.RecyclingMachine;
        }

        // GET: api/RecyclingMachine/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRecyclingMachine([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var recyclingMachine = await _context.RecyclingMachine.FindAsync(id);

            if (recyclingMachine == null)
            {
                return NotFound();
            }

            return Ok(recyclingMachine);
        }

        // PUT: api/RecyclingMachine/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRecyclingMachine([FromRoute] int id, [FromBody] RecyclingMachine recyclingMachine)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != recyclingMachine.MachineId)
            {
                return BadRequest();
            }

            _context.Entry(recyclingMachine).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecyclingMachineExists(id))
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

        // POST: api/RecyclingMachine
        [HttpPost]
        public async Task<IActionResult> PostRecyclingMachine([FromBody] RecyclingMachine recyclingMachine)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.RecyclingMachine.Add(recyclingMachine);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRecyclingMachine", new { id = recyclingMachine.MachineId }, recyclingMachine);
        }

        // DELETE: api/RecyclingMachine/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecyclingMachine([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var recyclingMachine = await _context.RecyclingMachine.FindAsync(id);
            if (recyclingMachine == null)
            {
                return NotFound();
            }

            _context.RecyclingMachine.Remove(recyclingMachine);
            await _context.SaveChangesAsync();

            return Ok(recyclingMachine);
        }

        private bool RecyclingMachineExists(int id)
        {
            return _context.RecyclingMachine.Any(e => e.MachineId == id);
        }
    }
}