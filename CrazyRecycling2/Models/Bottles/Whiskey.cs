using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyRecycling.Models.Bottles
{
    public class Whiskey : Bottle
    {
        public int Damage;

        public override string GetBottleInfo()
        {
            return Damage.ToString();
        }
    }
}
