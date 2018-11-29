using CrazyRecycling.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyRecycling.Controllers
{
    public class MachineController
    {
        public Collection<Machine> Machines { get; } = new Collection<Machine>();

        public void PopulateListAsShops(Collection<Point> locations, int imageId) //int IMG (1 = first img; 2 = second img)
        {
            if (locations == null)
            {
                throw new ArgumentNullException("locations", "locations is NULL");
            }
            Machine shop = new Shop(0, 0, 16, 16, imageId);

            foreach (var item in locations)
            {
                Machines.Add(shop.Clone());
                Machines.Last().PositionX = item.X;
                Machines.Last().PositionY = item.Y;
            }
        }

        public void PopulateListAsRecyclingMachines(Collection<Point> locations, int imageId)//int IMG (1 = first img; 2 = second img)
        {
            if (locations == null)
            {
                throw new ArgumentNullException("locations", "locations is NULL");
            }
            Machine recyclingMachine = new RecyclingMachine(0, 0, 16, 16, imageId);

            foreach (var item in locations)
            {
                Machines.Add(recyclingMachine.Clone());
                Machines.Last().PositionX = item.X;
                Machines.Last().PositionY = item.Y;
            }
        }
    }
}
