using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyRecycling.Models.Props
{
    public class MountainBuilder : MapPropBuilder
    {
        public override void BuildLocation(int X, int Y)
        {
            Prop.picture.Location = new Point(X, Y);
        }

        public override void BuildPictureBox()
        {
            Prop.picture.Image = global::CrazyRecycling.Properties.Resources.Mountain;
        }

        public override void BuildSize()
        {
            Prop.picture.Size = new Size(16, 16);
        }
    }
}
