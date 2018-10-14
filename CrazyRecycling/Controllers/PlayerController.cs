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
    public class PlayerController
    {
        public void Move(Player player, KeyEventArgs e)
        {
            int x = player.playerObject.Location.X;
            int y = player.playerObject.Location.Y;

            if (e.KeyCode == Keys.W)
            {
                y--;
            }
            else if (e.KeyCode == Keys.A)
            {
                x--;
            }
            else if (e.KeyCode == Keys.S)
            {
                y++;
            }
            else if (e.KeyCode == Keys.D)
            {
                x++;
            }
            player.playerObject.Location = new Point(x, y);
        }

        public Bottle ThrowBottle(Player player, KeyEventArgs e)
        {
            Bottle bottle = new Bottle();
            PictureBox bottlePic = new PictureBox();
            bottlePic.Image = global::CrazyRecycling.Properties.Resources.Bottle;
            bottlePic.Location = new Point(player.playerObject.Location.X, player.playerObject.Location.Y);
            bottlePic.Size = new Size(16, 16);
            bottle.picture = bottlePic;
            bottle.thrownDirection = new Point(1, 1);
            bottle.despawnTimer = 2;
            return bottle;
        }
    }
}
