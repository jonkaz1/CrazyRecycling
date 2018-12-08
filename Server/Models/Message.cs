using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models
{
    public class Message
    {
        [Key]
        public int MessageId { get; set; }
        public Player Player { get; set; }
        [Required]
        public string PlayerMessage { get; set; }
        public DateTime Created_At { get; set; }
    }
}
