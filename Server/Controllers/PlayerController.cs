﻿using System;
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
    public class PlayerController : ControllerBase
    {
        private readonly ServerContext _context;
        private Random random = new Random();

        public PlayerController(ServerContext context)
        {
            _context = context;
        }

        // GET: api/Player
        [HttpGet]
        public IEnumerable<Player> GetPlayer()
        {
            return _context.Player;
        }

        // GET: api/Player/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPlayer([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var player = await _context.Player.FindAsync(id);

            if (player == null)
            {
                return NotFound();
            }

            return Ok(player);
        }

        // PUT: api/Player/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlayer([FromRoute] int id, [FromBody] Player player)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != player.PlayerId)
            {
                return BadRequest();
            }


            _context.Entry(player).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlayerExists(id))
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

        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchPlayer([FromRoute] int id, [FromBody] Player player)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var p = await _context.Player.FindAsync(id);
            if (p == null)
            {
                return NotFound();
            }
            else
            {
                p.LastCheckTime = DateTime.Now;
                p.PosX = player.PosX;
                p.PosY = player.PosY;
                await _context.SaveChangesAsync();
            }
            return Ok();
        }

        // POST: api/Player
        [HttpPost]
        public async Task<IActionResult> PostPlayer([FromBody] Player player)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var dateCheck = DateTime.Now;
            dateCheck.AddMinutes(-30);
            List<Player> toDelete = new List<Player>();
            List<Bottle> toDeleteBottle = new List<Bottle>();			
            List<Message> toDeleteMessage = new List<Message>();
            foreach (var item in _context.Player)
            {
                if (item.LastCheckTime < dateCheck)
                {
                    foreach (var bottle in _context.Bottle.Where(x => x.PlayerId == item.PlayerId).Select(x => x))
                    {
                        toDeleteBottle.Add(bottle);
                    }
					foreach (var message in _context.Message.Where(x => x.Player.PlayerId == item.PlayerId).Select(x => x))
					{
						toDeleteMessage.Add(message);
					}
                    toDelete.Add(item);
                }
            }
			_context.Message.RemoveRange(toDeleteMessage);
            _context.Player.RemoveRange(toDelete);
            _context.Bottle.RemoveRange(toDeleteBottle);

            player.PosX = random.Next(1, 10);
            player.PosY = random.Next(1, 10);
            player.CharacterClass = CharacterClass.DefaultClass;
            player.SpawnTime = DateTime.Now;
            player.LastCheckTime = DateTime.Now;
            player.Bottles = new List<Bottle>();
            _context.Player.Add(player);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPlayer", new { id = player.PlayerId }, player);
        }

        // DELETE: api/Player/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlayer([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var player = await _context.Player.FindAsync(id);
            if (player == null)
            {
                return NotFound();
            }

            List<Message> toDeleteMessage = new List<Message>();
            List<Bottle> toDeleteBottle = new List<Bottle>();
            foreach (var bottle in _context.Bottle.Where(x => x.PlayerId == id).Select(x => x))
            {
                toDeleteBottle.Add(bottle);
            }
            foreach (var message in _context.Message.Where(x => x.Player.PlayerId == id).Select(x => x))
            {
                toDeleteMessage.Add(message);
            }
            _context.Message.RemoveRange(toDeleteMessage);
            _context.Bottle.RemoveRange(toDeleteBottle);
            _context.Player.Remove(player);
            await _context.SaveChangesAsync();

            return Ok(player);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAllPlayers()
        {
            await _context.Database.ExecuteSqlCommandAsync("TRUNCATE TABLE Player");
            return Ok();
        }        

        private bool PlayerExists(int id)
        {
            return _context.Player.Any(e => e.PlayerId == id);
        }
    }
}