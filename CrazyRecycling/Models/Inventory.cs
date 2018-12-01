using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyRecycling.Models
{
    public class Inventory
    {
        public InventoryItem MainBag { get; set; }

        public Inventory()
        {
            MainBag = new GarbageBag();
        }
    }
}
