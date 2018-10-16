using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrazyRecycling.Controllers
{
    public abstract class PlayerCommand
    {
        protected ServerConnector serverConnector;

        public PlayerCommand(ServerConnector serverConnector)
        {
            this.serverConnector = serverConnector;
        }

        public abstract void Execute();
    }
}
