using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyRecycling.Controllers.FacadeControllers
{
    public class PickupBottleCommand : PlayerCommand
    {
        private string BottleString { get; set; }

        public override void ChangeInnerValue(string value)
        {
            BottleString = "{\"Action\":0,\"BagDeepness\":0,\"BagPosition\":0," +
                "\"Bottles\":[{\"BottleId\":" + value + "}]}";
        }

        public override void Execute(string value)
        {
            proxyConnector.PatchAction(value, BottleString);
        }
    }
}
