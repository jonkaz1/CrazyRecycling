﻿using System;
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
            stats = new PlayerStats
            {
                HealthPoints = 10,
                Damage = 2,
                Color = 0,
                Speed = 2,
                PointsBoost = 1
            };
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
