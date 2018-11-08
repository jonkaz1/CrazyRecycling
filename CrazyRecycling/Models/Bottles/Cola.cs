using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyRecycling.Models.Bottles
{
    public class Cola : Bottle
    {
        public int Count;

        public override string GetBottleInfo()
        {
            return Count.ToString();
        }
    }
}
