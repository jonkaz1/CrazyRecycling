using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyRecycling.Models.Bottles
{
    public class PointBottleFactory : AbstractFactory
    {
        public override Bottle CreateBottle(string name)
        {
            switch (name)
            {
                case "Cola":
                    return new Cola() { Count = 1 };
                case "NukeCola":
                    return new NukeCola() { Count = 5 };
                default:
                    return new Cola() { Count = 1 };
            }
        }
    }
}
