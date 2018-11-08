using CrazyRecycling.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrazyRecycling.Models.Bottles
{
    public class PointBottleFactory : AbstractFactory
    {
        public override Bottle CreateBottle(string name)
        {
            switch (name)
            {
                case "Cola":
                    return new Cola()
                    {
                        Count = 1,
                        Image = new PictureBox()
                        {
                            Image = Resources.Cola,
                            BackColor = Color.Transparent
                        }
                    };
                case "NukeCola":
                    return new NukeCola()
                    {
                        Count = 5,
                        Image = new PictureBox()
                        {
                            Image = Resources.NukeCola,
                            BackColor = Color.Transparent
                        }
                    };
                default:
                    return null;
            }
        }
    }
}
