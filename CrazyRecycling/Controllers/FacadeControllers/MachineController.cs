using CrazyRecycling.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyRecycling.Controllers
{
    public class MachineController
    {
        public List<Machine> Machines = new List<Machine>();

        public void PopulateListAsShops(List<Point> locations, int IMG) //int IMG (1 = first img; 2 = second img)
        {
            Machine shop = new Shop(0, 0, 16, 16, IMG);

            foreach (var item in locations)
            {
                Machines.Add(shop.Clone());
                Machines.Last().PosX = item.X;
                Machines.Last().PosY = item.Y;
            }
        }

        public void PopulateListAsRecyclingMachines(List<Point> locations, int IMG)//int IMG (1 = first img; 2 = second img)
        {
            Machine recyclingMachine = new RecyclingMachine(0, 0, 16, 16, IMG);

            foreach (var item in locations)
            {
                Machines.Add(recyclingMachine.Clone());
                Machines.Last().PosX = item.X;
                Machines.Last().PosY = item.Y;
            }
        }
    }
}
