using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models
{
    public class BottleDTOContainer
    {
        public BottleDTO[] Bottles { get; set; }
        public BottleAction Action { get; set; }

        public int BagDeepness { get; set; }
        public int BagPosition { get; set; }
    }

    public class BottleDTO
    {
        public int BottleId { get; set; }
    }

    public enum BottleAction
    {
        PickUp,
        Deposit,
        Throw
    }
}
