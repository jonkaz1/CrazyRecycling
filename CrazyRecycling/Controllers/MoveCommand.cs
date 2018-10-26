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
        public string newLocation { get; set; }

        public MoveCommand(ServerConnector serverConnector, string newLocation) : base(serverConnector)
        {
            string[] split = newLocation.Split(';');
            this.newLocation = "{\"posX\":\"" + split[0] + "\",\"posY\":\"" + split[1] + "\"}";
        }

        public override void Execute(string value)
        {
            Task.Run(() => serverConnector.PatchAction(value, newLocation)).Wait();
        }

        public override void ChangeInnerValue(string value)
        {
            string[] split = value.Split(';');
            newLocation = "{\"posX\":\"" + split[0] + "\",\"posY\":\"" + split[1] + "\"}";
        }
    }
}
