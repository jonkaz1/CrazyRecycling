using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrazyRecycling.Models
{
    public abstract class Machine
    {
        public int PosX;
        public int PosY;
        public int SizeX;
        public int SizeY;
        public PictureBox Image;

        public abstract Machine Clone();
    }
}
