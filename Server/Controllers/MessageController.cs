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
    public class MessageController : ControllerBase
    {
        private ServerContext _context;

        private List<Message> temp = new List<Message>();
        public MessageController(ServerContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetComment()
        {
            var messages = _context.Message; //.Include(m => m.Player);
            return Ok(messages);
        }

        [HttpPost]
        public IActionResult CreateComment([FromBody]MessageDto messageDto)
        {
            var message = new Message();
            message.Created_At = DateTime.Now;
            message.PlayerMessage = messageDto.Message;
//           message.Player = _context.Player.Find(messageDto.PlayerId);
            _context.Message.Add(message);
            _context.SaveChanges();
            return Created("Created", message);
        }
    }
}