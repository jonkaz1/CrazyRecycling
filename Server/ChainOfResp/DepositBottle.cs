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
                foreach (var item in p.Bottles)
                {
                    if (item.BagDeepness == bottle.BagDeepness && item.BagPosition == bottle.BagPosition)
                    {
                        switch (item.BottleType)
                        {
                            case BottleType.Cola:
                                p.Points += 1;
                                toRemove.Add(item.BottleId);
                                break;
                            case BottleType.NukeCola:
                                toRemove.Add(item.BottleId);
                                p.Points += 5;
                                break;
                            default:
                                break;
                        }
                    }
                }
                Bottle b;
                for (int i = 0; i < toRemove.Count; i++)
                {
                    b = Context.Bottle.Find(toRemove[i]);
                    p.Bottles.Remove(b);
                    Context.Bottle.Remove(b);
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
