using CrazyRecycling.Controllers.PlayerControllerSubSystem;
using CrazyRecycling.Models;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrazyRecycling.Controllers
{
    public class PlayerController
    {
        private MovementController Movement = new MovementController();
        private ClassChangeController ClassChange = new ClassChangeController();
        CancellationTokenSource _cancelationTokenSource;

        public Player player;
        public Point oldLocation;

        public PlayerController(Player player)
        {
            this.player = player;
            oldLocation = new Point(player.PosX, player.PosY);
            _cancelationTokenSource = new CancellationTokenSource();
            new Task(() => UpdatePlayerLocation(), _cancelationTokenSource.Token, TaskCreationOptions.LongRunning).Start();
        }

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
                    player.PosY += -1;
                    player.playerObject.Location = new Point(player.PosX, player.PosY);
                    break;
                case Keys.A:
                    player.PosX += -1;
                    player.playerObject.Location = new Point(player.PosX, player.PosY);
                    break;
                case Keys.S:
                    player.PosY += 1;
                    player.playerObject.Location = new Point(player.PosX, player.PosY);
                    break;
                case Keys.D:
                    player.PosX += 1;
                    player.playerObject.Location = new Point(player.PosX, player.PosY);
                    break;
                default:
                    break;
            }
            
        }

        public async void UpdatePlayerLocation()
        {
            while (!_cancelationTokenSource.Token.IsCancellationRequested)
            {
                if (player.PosX != oldLocation.X || player.PosY != oldLocation.Y)
                {
                    commands[0].ChangeInnerValue(player.PosX + ";" + player.PosY);
                    commands[0].Execute("Player/" + player.PlayerId);
                    oldLocation.X = player.PosX;
                    oldLocation.Y = player.PosY;
                }
                else
                {
                    await Task.Delay(200);
                }
            }
        }
    }
}
