using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrazyRecycling.Models.Bottles;

namespace CrazyRecycling.Models
{
    class Brute : ICharacterClass
    {
        PlayerStats stats;

        public Brute()
        {
            stats = new PlayerStats
            {
                HealthPoints = 20,
                Damage = 4,
                Color = 10,
                Speed = 1,
                PointsBoost = 0
            };
        }

        public PlayerStats GetStats()
        {
            return stats;
        }

        /// <summary>
        /// Brute throw bottle implementation
        /// </summary>
        Bottle ICharacterClass.ThrowBottle(int X, int Y)
        {
            Bottle bottle = new PointBottleFactory().CreateBottle("Cola");
            PictureBox bottlePic = new PictureBox
            {
                Image = Properties.Resources.NukeCola,
                Location = new Point(X, Y),
                Size = new Size(16, 16)
            };
            bottle.Image = bottlePic;
            bottle.ThrownDirection = new Point(1, 1);
            bottle.TimeToDestroy = 2;
            return bottle;
        }
    }
}
