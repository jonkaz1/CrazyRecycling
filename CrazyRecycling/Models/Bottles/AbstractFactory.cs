using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyRecycling.Models.Bottles
{
    public abstract class AbstractFactory
    {
        public abstract Bottle CreateBottle(string name);
    }
}
