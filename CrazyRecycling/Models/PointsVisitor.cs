using CrazyRecycling.Models.Bottles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyRecycling.Models
{
    class PointsVisitor : IVisitor
    {
        public void Visit(Bottle element)
        {
            Bottle bottle = element as Bottle;

            //if (bottle.PointsCount != 0)
            //{
            //    bottle.PointsCount *= 2;
            //}
        }
    }
}
