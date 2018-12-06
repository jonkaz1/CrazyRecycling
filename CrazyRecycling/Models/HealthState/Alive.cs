using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyRecycling.Models.HealthState
{
    public class Alive : HealthState
    {
        public int HealthPoints { get; set; }

        public Alive(int healthPoints)
        {
            HealthPoints = healthPoints;
        }

        public override void Handle(int amount, Player player)
        {
            HealthPoints += amount;
            if (HealthPoints <= 0)
            {
                player.HealthState = new Dead();
            }
        }
    }
}
