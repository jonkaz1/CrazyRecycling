using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Server.Models;

namespace Server.Helper
{
    public class MachineDataCreator : DataCreator
    {
        public override void GenerateValues(ServerContext context)
        {
            var count = context.Machine.Count(x => x.MachineType == MachineType.RecyclingMachine);
            if (count < 8)
            {
                for (int i = count; i < 8; i++)
                {
                    context.Machine.Add(new Machine()
                    {
                        MachineType = MachineType.RecyclingMachine,
                        PosX = Randomizer.Next(1, 10),
                        PosY = Randomizer.Next(1, 10),
                        SizeX = 16,
                        SizeY = 16
                    });
                }
            }
            count = context.Machine.Count(x => x.MachineType == MachineType.Shop);
            if (count < 4)
            {
                for (int i = count; i < 4; i++)
                {
                    context.Machine.Add(new Machine()
                    {
                        MachineType = MachineType.Shop,
                        PosX = Randomizer.Next(1, 10),
                        PosY = Randomizer.Next(1, 10),
                        SizeX = 16,
                        SizeY = 16
                    });
                }
            }
        }
    }
}
