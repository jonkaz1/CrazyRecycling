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
        public async Task<IActionResult> Post([FromBody] int posX, [FromBody] int posY, [FromBody] int dirX, [FromBody] int dirY)
        {
            _context.Bottle.Add(new Vodka()
            {
                PosX = posX,
                PosY = posY,
                LastPosX = posX + dirX * 10,
                LastPosY = posY + dirY * 10,
                SpawnTime = DateTime.Now
            });

            await _context.SaveChangesAsync();

            return Ok();
        }

        // PUT: api/Projectile/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
