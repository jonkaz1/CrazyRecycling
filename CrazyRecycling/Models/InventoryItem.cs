using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyRecycling.Models
{
    public abstract class InventoryItem
    {
        public abstract InventoryItem GetItem();
        public abstract void Add(InventoryItem item);
        public abstract void Remove(InventoryItem item);
    }
}
