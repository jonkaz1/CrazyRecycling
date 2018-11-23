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
    class Hoarder : ICharacterClass
    {
        PlayerStats stats;

        public Hoarder()
        {
            stats = new PlayerStats();
            stats.HealthPoints = 10;
            stats.Damage = 2;
            stats.Color = -10;
            stats.Speed = 1;
            stats.PointsBoost = 4;
        }

        public PlayerStats GetStats()
        {
            return stats;
        }

        /// <summary>
        /// Hoarder throw bottle implementation
        /// </summary>
        Bottle ICharacterClass.ThrowBottle(int X, int Y)
        {
            Bottle bottle = new PointBottleFactory().CreateBottle("Cola");
            PictureBox bottlePic = new PictureBox();
            bottlePic.Image = global::CrazyRecycling.Properties.Resources.NukeCola;
            bottlePic.Location = new Point(X, Y);
            bottlePic.Size = new Size(16, 16);
            bottle.Image = bottlePic;
            bottle.ThrownDirection = new Point(1, 1);
            bottle.TimeToDestroy = 2;
            return bottle;
        }
    }
}
