using CrazyRecycling.Models.Bottles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyRecycling.Models
{
    class DamageVisitor : IVisitor
    {
        public void Visit(Bottle element)
        {
            Bottle bottle = element as Bottle;

            //if (bottle.Damage != 0)
            //{
            //    bottle.Damage *= 2;
            //}
        }
    }
}
