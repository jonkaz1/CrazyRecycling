using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyRecycling.Models
{
    class Hoarder : ICharacterClass
    {
        public int Color;
        public int PointsBoost;
        public Hoarder()
        {

        }
        public Hoarder(int color, int pointsBoost)
        {
            Color = color;
            PointsBoost = pointsBoost;
        }
        /// <summary>
        /// Hoarder throw bottle implementation
        /// </summary>
        public void ThrowBottle()
        {
            throw new NotImplementedException();
        }
    }
}
