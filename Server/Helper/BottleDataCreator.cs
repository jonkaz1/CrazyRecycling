using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Server.Models;

namespace Server.Helper
{
    public class BottleDataCreator : DataCreator
    {
        public override void GenerateValues(ServerContext context)
        {
            if (context.Bottle.Count() < 32)
            {
                BottleType bottleType;
                for (int i = 0; i < 8; i++)
                {
                    switch(Randomizer.Next(0, 100))
                    {
                        case 0:
                            bottleType = BottleType.Wine;
                            break;
                        case 1:
                            bottleType = BottleType.Whiskey;
                            break;
                        case 2:
                            bottleType = BottleType.Vodka;
                            break;
                        case 3:
                            bottleType = BottleType.GinOfDestruction;
                            break;
                        case 4:
                        case 5:
                            bottleType = BottleType.NukeCola;
                            break;
                        default:
                            bottleType = BottleType.Cola;
                            break;
                    }
                    context.Bottle.Add(new Bottle()
                    {
                        PosX = Randomizer.Next(16, 1000),
                        PosY = Randomizer.Next(16, 1000),
                        IsProjectile = false,
                        SpawnTime = DateTime.Now,
                        BottleType = bottleType
                    });
                }
            }
        }
    }
}
