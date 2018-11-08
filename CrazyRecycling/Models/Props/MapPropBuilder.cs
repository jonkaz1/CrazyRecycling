using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyRecycling.Models.Props
{
    public abstract class MapPropBuilder
    {
        public Prop Prop { get; set; } = new Prop();

        public abstract void BuildPictureBox();
        public abstract void BuildSize();
        public abstract void BuildLocation(int X, int Y);
    }
}
