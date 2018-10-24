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
        private string direction;

        public MoveCommand(ServerConnector serverConnector, string direction) : base(serverConnector)
        {
            string[] split = direction.Split(';');
            this.direction = "{\"posX\":\"" + split[0] + "\",\"posY\":\"" + split[1] + "\"}";
        }

        public override void Execute(string value)
        {
            Task.Run(() => serverConnector.PatchAction(value, direction)).Wait();
        }
    }
}
