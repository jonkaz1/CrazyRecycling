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
    public class MessageController : ControllerBase
    {
        private readonly ServerContext _context;

        private List<Message> temp = new List<Message>();
        public MessageController(ServerContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult CreateComment()
        {
            var messages = _context.Messages;
            return Ok(messages);
        }

        [HttpPost]
        public IActionResult CreateComment([FromBody]MessageDto messageDto)
        {
            Message message = new Message();
            var messagess = _context.Messages;
            message.Created_At = DateTime.Now;
            message.PlayerMessage = messageDto.Message;
            message.Player = _context.Player.Find(messageDto.PlayerId);
            var player = _context.Player.Find(messageDto.PlayerId);
            _context.Player.Find(messageDto.PlayerId).Messages.Add(message);
            _context.Messages.Add(message);
            var messages = _context.Messages;
            _context.SaveChanges();
            return Created("Created", message);
        }
    }
}