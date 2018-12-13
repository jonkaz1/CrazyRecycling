using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models
{
    public class MessageContext
    {
        public Player Player { get; set; }
        public string Message { get; set; }

        public MessageContext(Player player, string message)
        {
            this.Player = player;
            this.Message = message;
        }
    }
}
