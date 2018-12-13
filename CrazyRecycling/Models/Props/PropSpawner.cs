using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyRecycling.Models.Props
{
    public class PropSpawner
    {
        //Random rnd = new Random();
        public void Construct(MapPropBuilder builder)
        {
            //builder.BuildPictureBox();
            //builder.BuildSize();
            //builder.BuildLocation(rnd.Next(1, 853), rnd.Next(1, 594));
            builder.Build();
        }
    }
}
