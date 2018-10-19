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
        
        public override void Execute(string value)
        {
            switch (value)
            {
                case "W":
                    serverConnector.Action("Move;0,1");
                    break;
                case "A":
                    serverConnector.Action("Move;1,0");
                    break;
                case "S":
                    serverConnector.Action("Move;0,-1");
                    break;
                case "D":
                    serverConnector.Action("Move;-1,0");
                    break;
                default:
                    break;
            }
        }
    }
}
