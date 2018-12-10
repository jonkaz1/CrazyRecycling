using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Server.Models;

namespace Server.ChainOfResp
{
    public class ThrowBottle : Handler
    {
        public override Bottle HandleRequest(BottleDTOContainer bottle, int playerId)
        {
            if (bottle.Action == BottleAction.Throw)
            {
                var b = Context.Bottle.Find(bottle.Bottles[0].BottleId);
                var p = Context.Player.Find(playerId);
                p.Bottles.Remove(b);
                Context.Remove(b);
                
                return null;
            }
            else
            {
                return Successor.HandleRequest(bottle, playerId);
            }
        }
    }
}
