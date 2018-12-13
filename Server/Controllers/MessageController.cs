using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Helper.MessageInterpreter;
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
            var messages = _context.Message.Include(m => m.Player);
            return Ok(messages);
        }

        [HttpPost]
        public IActionResult CreateComment([FromBody]MessageDto messageDto)
        {
            MessageInterpreter interpreter = new MessageInterpreter();
            var message = new Message();
            Player player = _context.Player.Find(messageDto.PlayerId);
            var messageContext = new MessageContext(player, messageDto.Message);
            interpreter.ProcessMessage(ref messageContext);
            message.Created_At = DateTime.Now;
            message.PlayerMessage = messageContext.Message;
            message.Player = messageContext.Player;
            _context.Player.Find(messageContext.Player.PlayerId).HealthPoints = messageContext.Player.HealthPoints;
            _context.Message.Add(message);
            _context.SaveChanges();
            return Created("Created", message);
        }
    }
}