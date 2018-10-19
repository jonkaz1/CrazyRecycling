using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models
{
    public class Speedy : CharacterClass
    {
        public int HealthPoints { get; set; }
        public int Speed { get; set; }

        public Speedy()
        {

        }

        public override void ThrowBottle()
        {
            throw new NotImplementedException();
        }
    }
}
