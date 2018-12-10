using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyRecycling.Controllers.Memento
{
    public class CurrentProfile
    {
        public string PlayerName { get; set; }

        public Profile SaveProfile(string saveFile)
        {
            return new Profile(saveFile)
            {
                PlayerName = PlayerName                
            };
        }

        public void RestoreProfile(Profile profile)
        {
            PlayerName = profile.PlayerName;
        }
    }
}
