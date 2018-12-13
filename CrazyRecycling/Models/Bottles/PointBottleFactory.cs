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
                        //start of Jonas Visitor code
                        //Count = 1,
                        PointsCount = 1,
                        Damage = 0,
                        //end
                        Image = new PictureBox()
                        {
                            Image = Resources.Cola,
                            BackColor = Color.Transparent
                        }
                    };
                case "NukeCola":
                    return new NukeCola()
                    {
                        //start of Jonas Visitor code
                        //Count = 5,
                        PointsCount = 5,
                        Damage = 0,
                        //end
                        Image = new PictureBox()
                        {
                            Image = Resources.NukeCola,
                            BackColor = Color.Transparent
                        }
                    };
                default:
                    return new BottleNullObject();
            }
        }
    }
}
