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
    class DefaultClass : ICharacterClass
    {
        PlayerStats stats;

        public DefaultClass()
        {
            stats = new PlayerStats();
            stats.HealthPoints = 10;
            stats.Damage = 2;
            stats.Color = 0;
            stats.Speed = 1;
            stats.PointsBoost = 0;
        }

        public PlayerStats GetStats()
        {
            return stats;
        }

        /// <summary>
        /// DefaultClass ThrowBottle method
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
    public class PlayerStats
    {
        public int HealthPoints;
        public int Damage;
        public int Color;
        public int Speed;
        public int PointsBoost;
        public PlayerStats()
        {

        }
    }
}
