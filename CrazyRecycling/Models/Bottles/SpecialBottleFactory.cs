using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyRecycling.Models.Bottles
{
    public class SpecialBottleFactory : AbstractFactory
    {
        public override Bottle CreateBottle(string name)
        {
            switch (name)
            {
                case "Wine":
                    return new Wine();
                case "Vodka":
                    return new Vodka();
                case "Whiskey":
                    return new Whiskey();
                case "GinOfDestruction":
                    return new GinOfDestruction();
                default:
                    return new Wine();
            }
        }
    }
}
