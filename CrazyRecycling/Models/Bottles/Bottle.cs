using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrazyRecycling.Models.Bottles
{
    public abstract class Bottle
    {
        public int BottleId { get; set; }
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public PictureBox Image { get; set; }
        Rectangle Box { get; set; } = new Rectangle(new Point(16, 16), new Size(16, 16));
        public Point ThrownDirection { get; set; } = new Point();
        public float TimeToDestroy { get; set; } = 0;
        public bool IsNewlySpawned { get; set; }

        protected Bottle()
        {
            
        }

        public abstract string GetBottleInfo();
    }
}
