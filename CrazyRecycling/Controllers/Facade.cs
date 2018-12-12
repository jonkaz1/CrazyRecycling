using CrazyRecycling.Controllers;
using CrazyRecycling.Controllers.FacadeControllers;
using CrazyRecycling.Models;
using CrazyRecycling.Models.Bottles;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrazyRecycling
{
    class Facade
    {
        private PlayerController playerController;
        private LeaderboardController leaderboard = new LeaderboardController();
        private MachineController machineController = new MachineController();
        public AbstractServerConnector Connector { get; set; }
        
        public Facade()
        {
            Connector = ProxyConnector.Instance;
        }

        public void AttachPlayer(Player player)
        {
            playerController = new PlayerController(player);
        }

        public void AddCommand(string newLocation)
        {
            MoveCommand command = new MoveCommand(newLocation);
            playerController.AddCommand(command);
            playerController.AddCommand(new PickupBottleCommand());
            playerController.AddCommand(new UseObjectCommand());
        }

        public Bottle GetBottle(KeyEventArgs e)
        {
            return playerController.ThrowBottle(e);
        }

        public void PickUpBottle(int bottleId)
        {
            playerController.PickBottle(bottleId);
        }

        public void DepositBottle()
        {
            playerController.UseBottle();
        }

        public void ChangeLocation(KeyEventArgs e)
        {
            playerController.ChangeLocation(e);
        }

        public void UpdateLeaderBoard(JToken item, ref List<Player> PlayerList, ref Player MainPlayer)
        {
            Player p;
            Point point = new Point();
            p = PlayerList.FirstOrDefault(x => x.PlayerId == item["playerId"].Value<int>());
            point.X = item["posX"].Value<int>();
            point.Y = item["posY"].Value<int>();
            if (p == null)
            {
                p = new Player()
                {
                    PlayerId = item["playerId"].Value<int>(),
                    Name = item["name"].Value<string>(),
                    PositionX = point.X,
                    PositionY = point.Y,
                    Points = item["points"].Value<int>(),
                    IsNewlyCreated = true
                };
                PlayerList.Add(p);
            }
            else
            {
                p.Points = item["points"].Value<int>();
                if (p.PlayerId == MainPlayer.PlayerId && !IsPlayerTooFar(MainPlayer.PositionX, MainPlayer.PositionY, point.X, point.Y))
                {
                    return;
                }
                else
                {
                    p.PositionX = point.X;
                    p.PositionY = point.Y;
                    p.LocationChanged = true;
                }
            }
            leaderboard.UpdateLeaderboard(p);
        }
        private bool IsPlayerTooFar(int playerPosX, int playerPosY, int newPosX, int newPosY)
        {
            if (Math.Abs(playerPosX - newPosX) > 50 || Math.Abs(playerPosY - newPosY) > 50)
            {
                return true;
            }
            return false;
        }
    }



}
