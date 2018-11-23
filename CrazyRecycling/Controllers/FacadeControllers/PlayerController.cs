using CrazyRecycling.Models;
using CrazyRecycling.Models.Bottles;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrazyRecycling.Controllers
{
    public class PlayerController
    {
        CancellationTokenSource _cancelationTokenSource;

        public Player player;
        public Point oldLocation;

        public PlayerController(Player player)
        {
            this.player = player;
            oldLocation = new Point(player.PositionX, player.PositionY);
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

        /// <summary>
        /// Throwing bottle depends on character class
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public Bottle ThrowBottle(KeyEventArgs e)
        {
            Bottle bottle = player.CharacterClass.ThrowBottle(player.PlayerObject.Location.X, player.PlayerObject.Location.Y);
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
        
        public void ChangeLocation(KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    player.PositionY += -1;
                    player.PlayerObject.Location = new Point(player.PositionX, player.PositionY);
                    break;
                case Keys.A:
                    player.PositionX += -1;
                    player.PlayerObject.Location = new Point(player.PositionX, player.PositionY);
                    break;
                case Keys.S:
                    player.PositionY += 1;
                    player.PlayerObject.Location = new Point(player.PositionX, player.PositionY);
                    break;
                case Keys.D:
                    player.PositionX += 1;
                    player.PlayerObject.Location = new Point(player.PositionX, player.PositionY);
                    break;
                default:
                    break;
            }
            
        }

        /// <summary>
        /// Performs move command
        /// </summary>
        public async void UpdatePlayerLocation()
        {
            while (!_cancelationTokenSource.Token.IsCancellationRequested)
            {
                if (player.PositionX != oldLocation.X || player.PositionY != oldLocation.Y)
                {
                    commands[0].ChangeInnerValue(player.PositionX + ";" + player.PositionY);
                    commands[0].Execute("Player/" + player.PlayerId);
                    oldLocation.X = player.PositionX;
                    oldLocation.Y = player.PositionY;
                }
                else
                {
                    await Task.Delay(200);
                }
            }
        }

        public PlayerStats GetPlayerStats()
        {
            PlayerStats playerStats = player.CharacterClass.GetStats();
            return playerStats;
        }
    }
}
