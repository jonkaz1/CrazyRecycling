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
        private string NewLocation { get; set; }

        public MoveCommand(string newLocation)
        {
            string[] split = newLocation.Split(';');
            NewLocation = "{\"posX\":\"" + split[0] + "\",\"posY\":\"" + split[1] + "\"}";
        }

        public override void Execute(string value)
        {
            proxyConnector.PatchAction(value, NewLocation);
        }

        public override void ChangeInnerValue(string value)
        {
            string[] split = value.Split(';');
            NewLocation = "{\"posX\":\"" + split[0] + "\",\"posY\":\"" + split[1] + "\"}";
        }
    }
}
