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
        public string NewLocation { get; set; }

        public MoveCommand(ServerConnector serverConnector, string newLocation) : base(serverConnector)
        {
            string[] split = newLocation.Split(';');
            this.NewLocation = "{\"posX\":\"" + split[0] + "\",\"posY\":\"" + split[1] + "\"}";
        }

        public override void Execute(string value)
        {
            Task.Run(() => serverConnector.PatchAction(value, NewLocation)).Wait();
        }

        public override void ChangeInnerValue(string value)
        {
            string[] split = value.Split(';');
            NewLocation = "{\"posX\":\"" + split[0] + "\",\"posY\":\"" + split[1] + "\"}";
        }
    }
}
