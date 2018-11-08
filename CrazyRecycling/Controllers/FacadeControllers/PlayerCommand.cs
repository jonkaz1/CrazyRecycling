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

        public PlayerCommand()
        {
            serverConnector = ServerConnector.Instance();
        }

        public abstract void Execute(string value);

        public abstract void ChangeInnerValue(string value);
    }
}
