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
        public int PosX;
        public int PosY;
        public PictureBox picture;
        Rectangle box = new Rectangle(new Point(16, 16),new Size(16, 16));
        public Point thrownDirection = new Point();
        public float despawnTimer = 0;

        public Bottle()
        {
            
        }

        public abstract string GetBottleInfo();
    }
}
