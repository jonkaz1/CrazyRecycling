using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyRecycling.Models
{
    class Speedy : ICharacterClass
    {
        public int Speed;
        public int HealthPoints;
        public Speedy()
        {

        }
        public Speedy(int speed, int healtpoints)
        {
            Speed = speed;
            HealthPoints = healtpoints;
        }
        /// <summary>
        /// Speedy throw bottle implementation
        /// </summary>
        public void ThrowBottle()
        {
            throw new NotImplementedException();
        }
    }
}
