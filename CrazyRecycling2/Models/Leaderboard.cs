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

        public List<Standing> Standings;

        protected Leaderboard()
        {
            Standings = new List<Standing>();
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
        public int PlayerId;
        public string PlayerName;
        public int Points;
    }
}
