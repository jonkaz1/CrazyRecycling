using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models
{
    public class Hoarder : CharacterClass
    {
        public int PointsBoost { get; set; }
        public int Color { get; set; }

        public Hoarder()
        {
        }

        public override void ThrowBottle()
        {
            throw new NotImplementedException();
        }
    }
}
