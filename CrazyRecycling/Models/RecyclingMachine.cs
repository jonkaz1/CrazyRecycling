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
        public RecyclingMachine(int positionX, int positionY, int sizeX, int sizeY, int receivedImage)
        {
            PositionX = positionX;
            PositionY = positionY;
            SizeX = sizeX;
            SizeY = sizeY;
            if (receivedImage == 1)
            {
                Image = new PictureBox()
                {
                    Location = new Point(PositionX, PositionY),
                    Size = new Size(SizeX, SizeY),
                    Image = Properties.Resources.RecyclingMachine,
                    BackColor = Color.Transparent
                };
            }
            else if (receivedImage == 2)
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
        public RecyclingMachine(int positionX, int positionY, int sizeX, int sizeY)
        {
            PositionX = positionX;
            PositionY = positionY;
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
