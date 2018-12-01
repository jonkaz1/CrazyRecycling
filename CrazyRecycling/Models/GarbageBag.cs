using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyRecycling.Models
{
    public class GarbageBag : InventoryItem
    {
        public List<InventoryItem> Children { get; set; }

        public GarbageBag()
        {
            Children = new List<InventoryItem>();
        }

        public override void Add(InventoryItem item)
        {
            Children.Add(item);
        }

        public override InventoryItem GetItem()
        {
            return Children.Last();
        }

        public override void Remove(InventoryItem item)
        {
            Children.Remove(item);
        }
    }
}
