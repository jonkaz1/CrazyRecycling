using CrazyRecycling.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrazyRecycling.Controllers
{
    public class GenerationController
    {
        public PictureBox GenerateBottles()
        {
            
            Random random = new Random();
                PictureBox bottle = new PictureBox();
                bottle.Image = global::CrazyRecycling.Properties.Resources.Bottle;
                bottle.Location = new Point(random.Next(16, 640 - 16), random.Next(16, 480 - 16));
                bottle.Size = new Size(16, 16);
                return bottle;
                
           
        }

        public void NotifyPlayers()
        {

        }
    }
}
