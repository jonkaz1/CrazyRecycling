using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyRecycling.Models.Bottles
{
    public class BottleNullObject : Bottle
    {
        public override string GetBottleInfo()
        {
            return "Bottle not found, doing nothing";
        }
    }
}
