using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyRecycling.Models.HealthState
{
    public class Dead : HealthState
    {
        public int Timer { get; set; }

        public override void Handle(int amount, Player player)
        {
            Timer = amount;
            if (Timer < 0)
            {
                player.HealthState = new Alive(player.HealthPoints);
            }
        }
    }
}
