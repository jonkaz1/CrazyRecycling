using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Server.Models;

namespace Server.ChainOfResp
{
    public class DepositBottle : Handler
    {
        public override Bottle HandleRequest(BottleDTOContainer bottle)
        {
            if (bottle.Action == BottleAction.Deposit)
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
