using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrazyRecycling.Models
{
    public class Shop : Machine
    {
        public Shop(int positionX, int positionY, int sizeX, int sizeY)
        {
            PositionX = posX;
            PositionY = posY;
            SizeX = sizeX;
            SizeY = sizeY;

            Image = new PictureBox()
            {
                Location = new Point(PositionX, PositionY),
                Size = new Size(SizeX, SizeY),
                Image = Properties.Resources.Shop,
                BackColor = Color.Transparent
            };

        }
        public Shop(int positionX, int positionY, int sizeX, int sizeY, int image)
        {
            PositionX = posX;
            PositionY = posY;
            SizeX = sizeX;
            SizeY = sizeY;
            if (image == 1)
            {
                Image = new PictureBox()
                {
                    Location = new Point(PositionX, PositionY),
                    Size = new Size(SizeX, SizeY),
                    Image = Properties.Resources.Shop,
                    BackColor = Color.Transparent
                };
            }
            else if (image == 2)
            {
                Image = new PictureBox()
                {
                    Location = new Point(PositionX, PositionY),
                    Size = new Size(SizeX, SizeY),
                    Image = Properties.Resources.Shop2,
                    BackColor = Color.Transparent
                };
            }
        }

        public override Machine Clone()
        {
            return (Machine)MemberwiseClone();
        }
    }
}
