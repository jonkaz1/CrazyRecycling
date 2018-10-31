using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Helper;
using Server.Models;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BottleController : ControllerBase
    {
        private readonly ServerContext _context;
        private readonly Generator _generator;

        public BottleController(ServerContext context)
        {
            _generator = new BottleGenerator()
            {
                Creator = new BottleDataCreator()
            };
            _context = context;
        }

        // GET: api/Bottle
        [HttpGet]
        public IEnumerable<Bottle> GetBottle()
        {
            _generator.GenerateData(_context);
            _context.SaveChanges();
            return _context.Bottle;
        }

        // GET: api/Bottle/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBottle([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var bottle = await _context.Bottle.FindAsync(id);

            if (bottle == null)
            {
                return NotFound();
            }

            return Ok(bottle);
        }

        // PUT: api/Bottle/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBottle([FromRoute] int id, [FromBody] Bottle bottle)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != bottle.BottleId)
            {
                return BadRequest();
            }

            _context.Entry(bottle).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BottleExists(id))
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

        // POST: api/Bottle
        [HttpPost]
        public async Task<IActionResult> PostBottle([FromBody] Bottle bottle)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Bottle.Add(bottle);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBottle", new { id = bottle.BottleId }, bottle);
        }

        // DELETE: api/Bottle/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBottle([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var bottle = await _context.Bottle.FindAsync(id);
            if (bottle == null)
            {
                return NotFound();
            }

            _context.Bottle.Remove(bottle);
            await _context.SaveChangesAsync();

            return Ok(bottle);
        }

        private bool BottleExists(int id)
        {
            return _context.Bottle.Any(e => e.BottleId == id);
        }
    }
}