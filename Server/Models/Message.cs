using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models
{
    public class Message
    {
        public int MessageId { get; set; }
        public Player Player { get; set; }
        public string PlayerMessage { get; set; }
        public DateTime Created_At { get; set; }
    }
}
