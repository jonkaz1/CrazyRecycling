using CrazyRecycling.Models;
using CrazyRecycling.Models.Bottles;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrazyRecycling.Controllers
{
    public class PlayerController : IDisposable
    {
        CancellationTokenSource _cancelationTokenSource;

        public Player Player { get; set; }
        public Point OldLocation { get; set; }

        public PlayerController(Player player)
        {
            Player = player ?? throw new ArgumentNullException("player", "Player was null");
            OldLocation = new Point(player.PositionX, player.PositionY);
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
        /// <param name="keyEvent"></param>
        /// <returns></returns>
        public Bottle ThrowBottle(KeyEventArgs keyEvent)
        {
            if (keyEvent == null)
            {
                throw new ArgumentNullException("keyEvent", "KeyEvent was null");
            }
            switch (keyEvent.KeyCode)
            {
                case Keys.Space:
                    break;
                default:
                    break;
            }
            Bottle bottle = Player.CharacterClass.ThrowBottle(Player.PlayerObject.Location.X, Player.PlayerObject.Location.Y);
            return bottle;
        }
        public void PickBottle(int bottleId)
        {
            commands[1].ChangeInnerValue(bottleId.ToString());
            commands[1].Execute("Bottle/" + Player.PlayerId);
        }
        public void UseBottle()
        {
            commands[2].Execute("Bottle/" + Player.PlayerId + ";{\"Action\":1,\"BagDeepness\":0,\"BagPosition\":0," +
                "\"Bottles\":[{\"BottleId\":0}]}");
        }
        public void ChangeCharacterClass()
        {

        }

        public void ChangeLocation(KeyEventArgs keyEvent)
        {
            if (keyEvent == null)
            {
                throw new ArgumentNullException("keyEvent", "KeyEvent was null");
            }
            switch (keyEvent.KeyCode)
            {
                case Keys.W:
                    Player.PositionY += -1;
                    Player.PlayerObject.Location = new Point(Player.PositionX * 16, Player.PositionY * 16);
                    break;
                case Keys.A:
                    Player.PositionX += -1;
                    Player.PlayerObject.Location = new Point(Player.PositionX * 16, Player.PositionY * 16);
                    break;
                case Keys.S:
                    Player.PositionY += 1;
                    Player.PlayerObject.Location = new Point(Player.PositionX * 16, Player.PositionY * 16);
                    break;
                case Keys.D:
                    Player.PositionX += 1;
                    Player.PlayerObject.Location = new Point(Player.PositionX * 16, Player.PositionY * 16);
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
                if (Player.PositionX != OldLocation.X || Player.PositionY != OldLocation.Y)
                {
                    commands[0].ChangeInnerValue(Player.PositionX + ";" + Player.PositionY);
                    commands[0].Execute("Player/" + Player.PlayerId);
                    OldLocation = new Point(Player.PositionX, Player.PositionY);
                }
                else
                {
                    await Task.Delay(200);
                }
            }
        }

        public PlayerStats RetrievePlayerStats()
        {
            PlayerStats playerStats = Player.CharacterClass.GetStats();
            return playerStats;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // free managed resources
                if (_cancelationTokenSource != null)
                {
                    _cancelationTokenSource.Dispose();
                    _cancelationTokenSource = null;
                }
            }
        }
    }
}
