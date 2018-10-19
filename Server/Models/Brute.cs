using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models
{
    public class Brute : CharacterClass
    {
        public int HealthPoints { get; set; }
        public int Damage { get; set; }
        public int Color { get; set; }

        public Brute()
        {

        }

        public override void ThrowBottle()
        {
            throw new NotImplementedException();
        }
    }
}
