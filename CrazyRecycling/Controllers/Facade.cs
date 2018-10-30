using CrazyRecycling.Models;
using CrazyRecycling.Models.Bottles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrazyRecycling.Controllers
{
    class Facade
    {
        PlayerController playerController;
        GenerationController generator = new GenerationController();
        LeaderboardController leaderboard = new LeaderboardController();
        MachineController machineController = new MachineController();

        public void AttachPlayer(Player player)
        {
            playerController = new PlayerController(player);
        }

        public void AddCommand(ServerConnector serverConnector, string newLocation)
        {
            MoveCommand command = new MoveCommand(serverConnector, newLocation);
            playerController.AddCommand(command);
        }

        public Bottle GetBottle(KeyEventArgs e)
        {
            return playerController.ThrowBottle(e);
        }

        public void ChangeLocation(KeyEventArgs e)
        {
            playerController.ChangeLocation(e);
        }

        public void UpdateLeaderBoard(Player player) {
            leaderboard.UpdateLeaderboard(player);
        }
    }


}
