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
        public RecyclingMachine(int posX, int posY, int sizeX, int sizeY, int RecyclingIMG)
        {
            PositionX = posX;
            PositionY = posY;
            SizeX = sizeX;
            SizeY = sizeY;
            if (RecyclingIMG == 1)
            {
                Image = new PictureBox()
                {
                    Location = new Point(PositionX, PositionY),
                    Size = new Size(SizeX, SizeY),
                    Image = Properties.Resources.RecyclingMachine,
                    BackColor = Color.Transparent
                };
            }
            else if (RecyclingIMG == 2)
            {
                Image = new PictureBox()
                {
                    Location = new Point(PositionX, PositionY),
                    Size = new Size(SizeX, SizeY),
                    Image = Properties.Resources.Recyclingmachine2,
                    BackColor = Color.Transparent
                };
            }
        }
        public RecyclingMachine(int posX, int posY, int sizeX, int sizeY)
        {
            PositionX = posX;
            PositionY = posY;
            SizeX = sizeX;
            SizeY = sizeY;
            Image = new PictureBox()
            {
                Location = new Point(PositionX, PositionY),
                Size = new Size(SizeX, SizeY),
                Image = Properties.Resources.RecyclingMachine,
                BackColor = Color.Transparent
            };
        }

        public override Machine Clone()
        {
            return (Machine)MemberwiseClone();
        }
    }
}
