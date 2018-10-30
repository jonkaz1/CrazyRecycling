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
    public class MachineController : ControllerBase
    {
        private readonly ServerContext _context;

        public MachineController(ServerContext context)
        {
            _context = context;
        }

        // GET: api/RecyclingMachine
        [HttpGet]
        public IEnumerable<Machine> GetMachine()
        {
            return _context.Machine;
        }

        // GET: api/RecyclingMachine/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMachine([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var recyclingMachine = await _context.Machine.FindAsync(id);

            if (recyclingMachine == null)
            {
                return NotFound();
            }

            return Ok(recyclingMachine);
        }

        // PUT: api/RecyclingMachine/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMachine([FromRoute] int id, [FromBody] Machine machine)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != machine.MachineId)
            {
                return BadRequest();
            }

            _context.Entry(machine).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MachineExists(id))
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
        public async Task<IActionResult> PostMachine([FromBody] Machine machine)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Machine.Add(machine);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRecyclingMachine", new { id = machine.MachineId }, machine);
        }

        // DELETE: api/RecyclingMachine/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMachine([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var machine = await _context.Machine.FindAsync(id);
            if (machine == null)
            {
                return NotFound();
            }

            _context.Machine.Remove(machine);
            await _context.SaveChangesAsync();

            return Ok(machine);
        }

        private bool MachineExists(int id)
        {
            return _context.Machine.Any(e => e.MachineId == id);
        }
    }
}