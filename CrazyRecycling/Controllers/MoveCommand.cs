using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrazyRecycling.Controllers
{
    public class MoveCommand : PlayerCommand
    {
        public MoveCommand(ServerConnector serverConnector) : base(serverConnector)
        {

        }

        //Move?
        public override void Execute()
        {
            serverConnector.Action();
        }
    }
}
