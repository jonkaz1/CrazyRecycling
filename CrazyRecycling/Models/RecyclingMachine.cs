using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrazyRecycling.Models
{
    public class RecyclingMachine : Machine
    {
        public RecyclingMachine(int posX, int posY, int sizeX, int sizeY)
        {
            PosX = posX;
            PosY = posY;
            SizeX = sizeX;
            SizeY = sizeY;
            Image = new PictureBox() { Location = new Point(PosX, PosY), Size = new Size(SizeX, SizeY),
            Image = Properties.Resources.RecyclingMachine};
        }

        public override Machine Clone()
        {
            return (Machine)MemberwiseClone();
        }
    }
}
