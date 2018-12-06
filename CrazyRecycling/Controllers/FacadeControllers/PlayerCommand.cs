using CrazyRecycling.Controllers.FacadeControllers;
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
        protected ProxyConnector proxyConnector;

        public PlayerCommand()
        {
            proxyConnector = ProxyConnector.Instance;
        }

        public abstract void Execute(string value);

        public abstract void ChangeInnerValue(string value);
    }
}
