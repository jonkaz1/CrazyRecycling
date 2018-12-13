using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyRecycling.Models.Props
{
    public abstract class MapPropBuilder
    {
        public Prop Prop { get; set; } = new Prop();
        Random rnd = new Random();

        public abstract void BuildPictureBox();
        public abstract void BuildSize();
        //public abstract void BuildLocation(int X, int Y);

        public virtual void BuildLocation(int X, int Y)
        {
            Prop.Picture.Location = new Point(X, Y);
        }

        /// <summary>
        /// The 'Template Method'
        /// </summary>
        public void Build()
        {
            BuildPictureBox();
            BuildSize();
            BuildLocation(rnd.Next(1, 853), rnd.Next(1, 594));
        }
    }
}
