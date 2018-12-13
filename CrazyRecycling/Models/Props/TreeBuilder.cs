using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyRecycling.Models.Props
{
    public class TreeBuilder : MapPropBuilder
    {
        //public override void BuildLocation(int X, int Y)
        //{
        //    Prop.Picture.Location = new Point(X, Y);
        //}

        public override void BuildPictureBox()
        {
            Prop.Picture.Image = global::CrazyRecycling.Properties.Resources.Tree;
        }

        public override void BuildSize()
        {
            Prop.Picture.Size = new Size(16, 16);
        }
    }
}
