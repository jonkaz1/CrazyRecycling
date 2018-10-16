using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyRecycling.Models
{
    class Brute : ICharacterClass
    {
        public int HealthPoints;
        public int Damage;
        public int Color;
        public Brute()
        {

        }
        public Brute(int healthPoints, int damage, int color)
        {
            HealthPoints = healthPoints;
            Damage = damage;
            Color = color;
        }
        /// <summary>
        /// Brute throw bottle implementation
        /// </summary>
        public void ThrowBottle()
        {
            throw new NotImplementedException();
        }
    }
}
