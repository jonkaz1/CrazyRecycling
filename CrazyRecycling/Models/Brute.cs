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
            stats = new PlayerStats();
            stats.HealthPoints = 20;
            stats.Damage = 4;
            stats.Color = 10;
            stats.Speed = 1;
            stats.PointsBoost = 0;
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
            PictureBox bottlePic = new PictureBox();
            bottlePic.Image = global::CrazyRecycling.Properties.Resources.NukeCola;
            bottlePic.Location = new Point(X, Y);
            bottlePic.Size = new Size(16, 16);
            bottle.Image = bottlePic;
            bottle.thrownDirection = new Point(1, 1);
            bottle.despawnTimer = 2;
            return bottle;
        }
    }
}
