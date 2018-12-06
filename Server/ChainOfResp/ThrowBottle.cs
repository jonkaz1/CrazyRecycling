using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Server.Models;

namespace Server.ChainOfResp
{
    public class ThrowBottle : Handler
    {
        public override Bottle HandleRequest(BottleDTOContainer bottle)
        {
            if (bottle.Action == BottleAction.Throw)
            {
                return null;
            }
            else
            {
                return Successor.HandleRequest(bottle);
            }
        }
    }
}
