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
    class Speedy : ICharacterClass
    {
        PlayerStats stats;

        public Speedy()
        {
            stats = new PlayerStats();
            stats.HealthPoints = 10;
            stats.Damage = 2;
            stats.Color = 0;
            stats.Speed = 2;
            stats.PointsBoost = 1;
        }

        public PlayerStats GetStats()
        {
            return stats;
        }

        /// <summary>
        /// Speedy throw bottle implementation
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
