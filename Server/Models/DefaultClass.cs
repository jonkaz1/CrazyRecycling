using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models
{
    public class DefaultClass : CharacterClass
    {
        public AttackEffect Effect { get; set; }

        public DefaultClass()
        {

        }

        public override void ThrowBottle()
        {
            throw new NotImplementedException();
        }
    }
}
