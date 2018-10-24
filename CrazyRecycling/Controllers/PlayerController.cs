using CrazyRecycling.Controllers.PlayerControllerSubSystem;
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
        private MovementController Movement = new MovementController();
        private ClassChangeController ClassChange  = new ClassChangeController();

        public Player player;

        private List<PlayerCommand> commands = new List<PlayerCommand>();

        public void AddCommand(PlayerCommand command)
        {
            commands.Add(command);
        }

        public void RemoveCommandAt(int index)
        {
            commands.RemoveAt(index);
        }

        public Bottle ThrowBottle(KeyEventArgs e)
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
        public void PickBottle()
        {

        }
        public void UseBottle()
        {

        }
        public void ChangeCharacterClass()
        {

        }

        public void SendAction(KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    commands[0].Execute("Player/" + player.PlayerId);
                    break;
                case Keys.A:
                    commands[1].Execute("Player/" + player.PlayerId);
                    break;
                case Keys.S:
                    commands[2].Execute("Player/" + player.PlayerId);
                    break;
                case Keys.D:
                    commands[3].Execute("Player/" + player.PlayerId);
                    break;
                default:
                    break;
            }
        }
    }
}
