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
            var standing = leaderboard.Standings.Find(x => x.PlayerId == player.PlayerId);
            if (standing == null)
            {
                leaderboard.Standings.Add(new Standing() {
                    PlayerId = player.PlayerId,
                    PlayerName = player.Name,
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
            leaderboard.Standings.RemoveAll(x => x.PlayerId == playerId);
        }
    }
}
