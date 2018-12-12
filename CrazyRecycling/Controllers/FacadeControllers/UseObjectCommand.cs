using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyRecycling.Controllers.FacadeControllers
{
    public class UseObjectCommand : PlayerCommand
    {
        public override void ChangeInnerValue(string value)
        {
            throw new NotImplementedException();
        }

        public override void Execute(string value)
        {
            var split = value.Split(';');
            proxyConnector.PatchAction(split[0], split[1]);
        }
    }
}
