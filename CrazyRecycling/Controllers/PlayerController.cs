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

        public void Move(KeyEventArgs e)
        {
            int x = player.playerObject.Location.X;
            int y = player.playerObject.Location.Y;

            switch (e.KeyCode)
            {
                case Keys.W://up
                    player.playerObject.Location = Movement.MoveUp(x, y);
                break;
            case Keys.A://left
                    player.playerObject.Location = Movement.MoveLeft(x, y);
                break;
            case Keys.S://down
                    player.playerObject.Location = Movement.MoveDown(x, y);
                break;
            case Keys.D://right
                player.playerObject.Location = Movement.MoveRight(x, y);
                break;
            default:
                break;
            }
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

        }
    }
}
