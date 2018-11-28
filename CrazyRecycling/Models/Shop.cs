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
        public Shop(int posX, int posY, int sizeX, int sizeY)
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
        public Shop(int posX, int posY, int sizeX, int sizeY, int shopIMG)
        {
            PositionX = posX;
            PositionY = posY;
            SizeX = sizeX;
            SizeY = sizeY;
            if (shopIMG == 1)
            {
                Image = new PictureBox()
                {
                    Location = new Point(PositionX, PositionY),
                    Size = new Size(SizeX, SizeY),
                    Image = Properties.Resources.Shop,
                    BackColor = Color.Transparent
                };
            }
            else if (shopIMG == 2)
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
