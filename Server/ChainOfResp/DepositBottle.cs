using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Server.Models;

namespace Server.ChainOfResp
{
    public class DepositBottle : Handler
    {
        public override Bottle HandleRequest(BottleDTOContainer bottle, int playerId)
        {
            if (bottle.Action == BottleAction.Deposit)
            {
                var p = Context.Player.Find(playerId);
                var machine = Context.Machine.FirstOrDefault(x =>
                x.MachineType == MachineType.RecyclingMachine && x.PosX == p.PosX && x.PosY == p.PosY);
                if (machine == null)
                {
                    return null;
                }
                var toRemove = new List<int>();
                var Colas = Context.Bottle.Where(x => x.BagDeepness == bottle.BagDeepness 
                && x.BagPosition == bottle.BagPosition 
                && (x.BottleType == BottleType.Cola || x.BottleType == BottleType.NukeCola));
                foreach (var item in Colas)
                {
                    switch (item.BottleType)
                    {
                        case BottleType.Cola:
                            p.Points += 1;
                            break;
                        case BottleType.NukeCola:
                            p.Points += 5;
                            break;
                        default:
                            break;
                    }
                    Context.Bottle.Remove(item);
                }
                return null;
            }
            else
            {
                return Successor.HandleRequest(bottle, playerId);
            }
        }
    }
}
