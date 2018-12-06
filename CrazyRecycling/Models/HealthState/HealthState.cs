using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyRecycling.Models.HealthState
{
    public abstract class HealthState
    {               
        public abstract void Handle(int amount, Player player);
    }
}
