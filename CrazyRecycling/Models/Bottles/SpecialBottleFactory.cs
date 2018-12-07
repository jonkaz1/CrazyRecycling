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
    public class SpecialBottleFactory : AbstractFactory
    {
        public override Bottle CreateBottle(string name)
        {
            switch (name)
            {
                case "Wine":
                    return new Wine() {
                        Damage = 1,
                        PointsCount = 0,
                        Image = new PictureBox()
                        {
                            Image = Resources.Wine,
                            BackColor = Color.Transparent
                        }
                    };
                case "Vodka":
                    return new Vodka()
                    {
                        Damage = 2,
                        PointsCount = 0,
                        Image = new PictureBox()
                        {
                            Image = Resources.Vodka,
                            BackColor = Color.Transparent
                        }
                    };
                case "Whiskey":
                    return new Whiskey()
                    {
                        Damage = 3,
                        PointsCount = 0,
                        Image = new PictureBox()
                        {
                            Image = Resources.Whiskey,
                            BackColor = Color.Transparent
                        }
                    };
                case "GinOfDestruction":
                    return new GinOfDestruction()
                    {
                        Damage = 10,
                        PointsCount = 0,
                        Image = new PictureBox()
                        {
                            Image = Resources.GinOfDestruction,
                            BackColor = Color.Transparent
                        }
                    };
                default:
                    return null;
            }
        }
    }
}
