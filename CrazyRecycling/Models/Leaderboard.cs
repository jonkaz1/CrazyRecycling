using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyRecycling.Models
{
    public class Leaderboard
    {
        private static Leaderboard _instance;

        public List<Standing> standings;

        protected Leaderboard()
        {
            standings = new List<Standing>();
        }

        public static Leaderboard Instance()
        {
            if (_instance == null)
            {
                _instance = new Leaderboard();
            }
            return _instance;
        }


    }

    public class Standing
    {
        public int playerId;
        public string playerName;
        public int Points;
    }
}
