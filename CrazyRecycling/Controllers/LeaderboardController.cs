using CrazyRecycling.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyRecycling.Controllers
{
    public class LeaderboardController
    {
        public Leaderboard leaderboard;

        public LeaderboardController()
        {
            leaderboard = Leaderboard.Instance();            
        }

        public void UpdateLeaderboard(Player player)
        {
            var standing = leaderboard.standings.Find(x => x.playerId == player.PlayerId);
            if (standing == null)
            {
                leaderboard.standings.Add(new Standing() {
                    playerId = player.PlayerId,
                    playerName = player.Name,
                    Points = player.Points
                });
            }
            else
            {
                standing.Points = player.Points;
            }
        }

        public void RemoveFromLeaderboard(int playerId)
        {
            leaderboard.standings.RemoveAll(x => x.playerId == playerId);
        }
    }
}
