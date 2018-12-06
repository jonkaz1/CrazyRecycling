using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Server.Models;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectileController : ControllerBase
    {
        private readonly ServerContext _context;

        public ProjectileController(ServerContext context)
        {
            _context = context;
        }

        // GET: api/Projectile
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Projectile/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Projectile
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Bottle bottle)
        {
            
            bottle.SpawnTime = DateTime.Now;
            bottle.LastPosX = bottle.PosX + bottle.LastPosX * 10;
            bottle.LastPosY = bottle.PosX + bottle.LastPosY * 10;
            _context.Bottle.Add(bottle);

            await _context.SaveChangesAsync();

            return Ok();
        }

        // PUT: api/Projectile/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Bottle bottle)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
