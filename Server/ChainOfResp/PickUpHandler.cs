using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Server.Models;

namespace Server.ChainOfResp
{
    public class PickUpHandler : Handler
    {
        public override Bottle HandleRequest(BottleDTOContainer bottle, int playerId)
        {
            if (bottle.Action == BottleAction.PickUp)
            {
                var b = Context.Bottle.Find(bottle.Bottles[0].BottleId);
                var p = Context.Player.Find(playerId);
                b.BagDeepness = bottle.BagDeepness;
                b.BagPosition = bottle.BagPosition;
                p.Bottles.Add(b);
                return b;
            }
            else
            {
                return Successor.HandleRequest(bottle, playerId);
            }
        }
    }
}
