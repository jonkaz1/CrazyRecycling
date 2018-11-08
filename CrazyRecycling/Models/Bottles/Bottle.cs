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
        public int BottleId;
        public int PosX;
        public int PosY;
        public PictureBox Image;
        Rectangle box = new Rectangle(new Point(16, 16),new Size(16, 16));
        public Point thrownDirection = new Point();
        public float despawnTimer = 0;
        public bool IsNewlySpawned;

        public Bottle()
        {
            
        }

        public abstract string GetBottleInfo();
    }
}
